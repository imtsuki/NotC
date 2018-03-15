// ***********************************************************************
// Assembly         : C
// Author           : Jason Qiu
// Created          : 03-14-2018
//
// Last Modified By : Jason Qiu
// Last Modified On : 03-15-2018
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
        /// Exprs this instance.
        /// </summary>
        public void Expr()
        {
            switch (Lookahead.Kind)
            {
                case TokenKind.INT:
                    INT();
                    Rest();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Ints this instance.
        /// </summary>
        /// <exception cref="Exception">INT not matched</exception>
        public void INT()
        {
            if (Lookahead.Kind == TokenKind.INT)
            {
                Console.Write($"[{((TokenInt)Lookahead).Val}]");
                Lookahead = NextTerminal();
            }
            else
            {
                throw new Exception("INT not matched");
            }
            
        }

        /// <summary>
        /// Rests this instance.
        /// </summary>
        public void Rest()
        {
            switch (Lookahead.Kind)
            {
                case TokenKind.OPERATOR:
                    switch (((TokenOperator)Lookahead).Val)
                    {
                        case OperatorVal.ADD:
                            ADD();
                            INT();
                            Console.Write("+");
                            Rest();
                            break;
                        case OperatorVal.SUB:
                            SUB();
                            INT();
                            Console.Write("-");
                            Rest();
                            break;
                        default:
                            break;

                    }
                    break;
            }
        }

        /// <summary>
        /// Adds this instance.
        /// </summary>
        public void ADD()
        {
            Lookahead = NextTerminal();
        }

        /// <summary>
        /// Subs this instance.
        /// </summary>
        public void SUB()
        {
            Lookahead = NextTerminal();
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
        /// Nexts the terminal.
        /// </summary>
        /// <returns>Token.</returns>
        Token NextTerminal()
        {
            lookaheadPosition++;
            return Tokens[lookaheadPosition];
        }
        
    }
}
