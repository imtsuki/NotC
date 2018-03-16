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
        public ASTExpression Parse()
        {
            return new ASTExpression();
        }

        /// <summary>
        /// Exprs this instance.
        /// </summary>
        public void Expr()
        {
            Term();
            while (true)
            {
                switch (Lookahead.Kind)
                {
                    case TokenKind.OPERATOR:
                        switch (((TokenOperator)Lookahead).Val)
                        {
                            case OperatorVal.ADD:
                                Match(OperatorVal.ADD);
                                Term();
                                Console.Write("+");
                                break;
                            case OperatorVal.SUB:
                                Match(OperatorVal.SUB);
                                Term();
                                Console.Write("-");
                                break;
                            default:
                                return;
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Terms this instance.
        /// </summary>
        /// <exception cref="Exception">Syntax Error</exception>
        public void Term()
        {
            Factor();
            while (true)
            {
                switch (Lookahead.Kind)
                {
                    case TokenKind.OPERATOR:
                        switch (((TokenOperator)Lookahead).Val)
                        {
                            case OperatorVal.MULT:
                                Match(OperatorVal.MULT);
                                Factor();
                                Console.Write("*");
                                break;
                            case OperatorVal.DIV:
                                Match(OperatorVal.DIV);
                                Factor();
                                Console.Write("/");
                                break;
                            default:
                                return;
                        }
                        break;
                }
            }
        }

        public void Factor()
        {
            if (Lookahead.Kind == TokenKind.INT)
            {
                Console.Write($"[{((TokenInt)Lookahead).Val}]");
                Match(TokenKind.INT);
            }
            else if (Lookahead.Kind == TokenKind.IDENTIFIER)
            {
                Console.Write($"[{((TokenIdentifier)Lookahead).Val}]");
                Match(TokenKind.IDENTIFIER);
            }
            else if (Lookahead.Kind == TokenKind.OPERATOR)
            {
                Match(OperatorVal.LPAREN);
                Expr();
                Match(OperatorVal.RPAREN);
            }
            else
            {
                throw new Exception("Syntax Error");
            }
        }

        /// <summary>
        /// The tokens
        /// </summary>
        private IList<Token> Tokens;
        /// <summary>
        /// The lookahead position
        /// </summary>
        private Int32 lookaheadPosition = -1;

        /// <summary>
        /// The lookahead
        /// </summary>
        private Token Lookahead;

        /// <summary>
        /// The current environment
        /// </summary>
        private Environment CurrentEnvironment = new Environment(previous: null);

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
