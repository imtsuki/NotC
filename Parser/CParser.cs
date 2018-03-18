// ***********************************************************************
// Assembly         : C
// Author           : Jason Qiu
// Created          : 03-14-2018
//
// Last Modified By : Jason Qiu
// Last Modified On : 03-16-2018
// ***********************************************************************
// <copyright file="CParser.cs" company="C">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using C.Tokenizer;
using C.AST;
using System.Linq;

namespace C.Parser
{
    /// <summary>
    /// Class CParser.
    /// </summary>
    class CParser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CParser"/> class.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        public CParser(IList<Token> tokens)
        {
            Tokens = tokens;
            Lookahead = NextTerminal();
        }

        /// <summary>
        /// Parses the given Tokens to its AST representation.
        /// </summary>
        /// <returns>The root node of the given Tokens' AST.</returns>
        public Expression Parse()
        {
            return Expr();
        }

        /// <summary>
        /// Production Expr:
        /// Expr  -> | Term RestE
        /// RestE -> | + Term {+} RestE
		///          | - Term {-} RestE
		///          | ε
        /// </summary>
        /// <returns>Expression Node.</returns>
        private Expression Expr()
        {
            Expression parent = Term();
            Expression leftTerm = parent;
            Expression rightTerm = null;
            
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
        private Expression Term()
        {
            Expression parent = Factor();
            Expression leftFactor = parent;
            Expression rightFactor = null;
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
        private Expression Factor()
        {
            Expression result = null;
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
                throw new Exception("Syntax Error");
            }
            return result;
        }

        /// <summary>
        /// The tokens
        /// </summary>
        private IList<Token> Tokens { get; set; }
        /// <summary>
        /// The lookahead position
        /// </summary>
        private Int32 lookaheadPosition { get; set; } = -1;

        /// <summary>
        /// The lookahead
        /// </summary>
        private Token Lookahead { get; set; }

        /// <summary>
        /// The current environment
        /// </summary>
        private Environment CurrentEnvironment { get; set; } = new Environment(previous: null);

        /// <summary>
        /// Returns the next terminal.
        /// </summary>
        /// <returns>Next terminal.</returns>
        private Token NextTerminal()
        {
            lookaheadPosition++;
            return Tokens[lookaheadPosition];
            
        }

        /// <summary>
        /// Matches the specified terminal.
        /// </summary>
        /// <param name="term">The terminal.</param>
        /// <exception cref="Exception">
        /// </exception>
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
                    throw new Exception($"{term} Not Matched");
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
                    throw new Exception($"{term} Not Matched");
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
                    throw new Exception($"{term} Not Matched");
                }
            }
        }  
    }
}
