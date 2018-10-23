using System;
using System.Collections.Generic;
using System.Text;
using NotC.LexicalAnalysis;
using NotC.AST;
using System.Linq;

namespace NotC.Parser
{
    public class CParser
    {
        public List<string> ParseErrors = new List<string>();
        public CParser(IEnumerable<Token> tokens)
        {
            Tokens = (IList<Token>)tokens;
            Lookahead = NextTerminal();
        }

        public ASTStatement Parse()
        {
            return Stmt();
        }

        private IList<ASTStatement> Stmts()
        {
            List<ASTStatement> stmts = new List<ASTStatement>();
            while (!(Lookahead.Kind == TokenKind.EOF ||
                    (Lookahead.Kind == TokenKind.OPERATOR && ((TokenOperator)Lookahead).Val == OperatorVal.RCURL)))
            {
                stmts.Add(Stmt());
            }
            return stmts;
        }
        
        private ASTStatement Stmt()
        {
            ASTStatement stmt = null;
            switch (Lookahead.Kind)
            {
                case TokenKind.KEYWORD:
                    switch (((TokenKeyword)Lookahead).Val)
                    {
                        case KeywordVal.IF:
                            stmt = If();
                            break;
                    }
                    break;
                case TokenKind.OPERATOR:
                    switch (((TokenOperator)Lookahead).Val)
                    {
                        case OperatorVal.LCURL:
                            stmt = Block();
                            break;
                    }
                    break;
                case TokenKind.IDENTIFIER:
                case TokenKind.INT:
                    stmt = Assign();
                    Match(OperatorVal.SEMICOLON);
                    break;
            }
            return stmt;
        }

        private If If()
        {
            Match(KeywordVal.IF);
            Match(OperatorVal.LPAREN);
            ASTExpression condition = Expr();
            Match(OperatorVal.RPAREN);
            ASTStatement trueBody = Stmt();
            return new If(condition, trueBody);
        }

        private Block Block()
        {
            Match(OperatorVal.LCURL);
            CurrentEnvironment = new Environment(CurrentEnvironment);
            var stmts = Stmts();
            CurrentEnvironment = CurrentEnvironment.Previous;
            Match(OperatorVal.RCURL);
            return new Block(stmts);
        }

        private ASTExpression Assign()
        {
            ASTExpression parent = Expr();
            ASTExpression leftExpr = parent;
            ASTExpression rightExpr = null;

            while (true)
            {
                switch (Lookahead.Kind)
                {
                    case TokenKind.OPERATOR:
                        switch (((TokenOperator)Lookahead).Val)
                        {
                            case OperatorVal.ASSIGN:
                                Match(OperatorVal.ASSIGN);
                                rightExpr = Expr();
                                parent = new Assign(leftExpr, rightExpr);
                                leftExpr = parent;
                                break;
                            default:
                                return parent;
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Production Expr:
        /// Expr  -> | Term RestE
        /// RestE -> | + Term {+} RestE
		///          | - Term {-} RestE
		///          | ε
        /// </summary>
        /// <returns>Expression Node.</returns>
        public ASTExpression Expr()
        {
            ASTExpression parent = Term();
            ASTExpression leftTerm = parent;
            ASTExpression rightTerm = null;
            
            while (true)
            {
                switch (Lookahead.Kind)
                {
                    case TokenKind.OPERATOR:
                        switch (((TokenOperator)Lookahead).Val)
                        {
                            case OperatorVal.ADD:
                                Match(OperatorVal.ADD);
                                rightTerm = Term();
                                parent = new Add(leftTerm, rightTerm);
                                leftTerm = parent;
                                break;
                            case OperatorVal.SUB:
                                Match(OperatorVal.SUB);
                                rightTerm = Term();
                                parent = new Sub(leftTerm, rightTerm);
                                leftTerm = parent;
                                break;
                            default:
                                return parent;
                        }
                        break;
                    default:
                        return parent;
                }
            }
        }

        /// <summary>
        /// Production Term:
        /// Term  -> | Factor RestT
        /// RestT -> | * Factor {*} RestT
        ///          | / Factor {/} RestT
        ///          | ε
        /// </summary>
        /// <returns>Expression Node.</returns>
        private ASTExpression Term()
        {
            ASTExpression parent = Factor();
            ASTExpression leftFactor = parent;
            ASTExpression rightFactor = null;
            while (true)
            {
                switch (Lookahead.Kind)
                {
                    case TokenKind.OPERATOR:
                        switch (((TokenOperator)Lookahead).Val)
                        {
                            case OperatorVal.MULT:
                                Match(OperatorVal.MULT);
                                rightFactor = Factor();
                                parent = new Mult(leftFactor, rightFactor);
                                leftFactor = parent;
                                break;
                            case OperatorVal.DIV:
                                Match(OperatorVal.DIV);
                                rightFactor = Factor();
                                parent = new Div(leftFactor, rightFactor);
                                leftFactor = parent;
                                break;
                            default:
                                return parent;
                        }
                        break;
                    default:
                        return parent;
                }
            }
        }

        /// <summary>
        /// Production Factor:
        /// Factor-> | IntNumber
        ///          | Id
        ///          | ( Expr )
        /// </summary>
        /// <returns>Expression Node.</returns>
        private ASTExpression Factor()
        {
            ASTExpression result = null;
            if (Lookahead.Kind == TokenKind.INT)
            {
                result = new IntNumber((TokenInt)Lookahead);
                Match(TokenKind.INT);
            }
            else if (Lookahead.Kind == TokenKind.IDENTIFIER)
            {
                // This line is remained only for test purpose. 
                // Shall be removed after Environment is fully implemented.  
                CurrentEnvironment.Put((TokenIdentifier)Lookahead);
                // ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
                result = new Id(CurrentEnvironment.Get((TokenIdentifier)Lookahead));
                Match(TokenKind.IDENTIFIER);
            }
            else if (Lookahead.Kind == TokenKind.OPERATOR)
            {
                Match(OperatorVal.LPAREN);
                result = Expr();
                Match(OperatorVal.RPAREN);
            }
            else
            {
                ParseErrors.Add("Syntax Error");
            }
            return result;
        }

        private IList<Token> Tokens { get; set; }
        private Int32 lookaheadPosition { get; set; } = -1;
        private Token Lookahead { get; set; }
        private Environment CurrentEnvironment { get; set; } = new Environment(previous: null);
        private Token NextTerminal()
        {
            lookaheadPosition++;
            return Tokens[lookaheadPosition];
            
        }

        private void Match(object term)
        {
            if (term.GetType().Equals(typeof(KeywordVal)))
            {
                if (Lookahead.Kind == TokenKind.KEYWORD 
                    && ((TokenKeyword)Lookahead).Val == (KeywordVal)term)
                {
                    Lookahead = NextTerminal();
                }
                else
                {
                    ParseErrors.Add($"Got {Lookahead}, Expected {term}");
                }
            }
            else if (term.GetType().Equals(typeof(OperatorVal)))
            {
                if (Lookahead.Kind == TokenKind.OPERATOR
                    && ((TokenOperator)Lookahead).Val == (OperatorVal)term)
                {
                    Lookahead = NextTerminal();
                }
                else
                {
                    ParseErrors.Add($"Got {Lookahead}, Expected {term}");
                }
            }
            else if (term.GetType().Equals(typeof(TokenKind)))
            {
                if (Lookahead.Kind == (TokenKind)term)
                {
                    Lookahead = NextTerminal();
                }
                else
                {
                    ParseErrors.Add($"Got {Lookahead}, Expected {term}");
                }
            }
        }  
    }
}
