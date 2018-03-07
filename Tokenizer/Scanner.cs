// ***********************************************************************
// Assembly         : C
// Author           : super
// Created          : 03-06-2018
//
// Last Modified By : super
// Last Modified On : 03-06-2018
// ***********************************************************************
// <copyright file="Scanner.cs" company="C">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C.Tokenizer
{
    /// <summary>
    /// Class Scanner.
    /// </summary>
    public class Scanner
    {
        /// <summary>
        /// Enum StateOperator
        /// </summary>
        public enum StateOperator
        {
            /// <summary>
            /// The start
            /// </summary>
            START,
            /// <summary>
            /// The finish
            /// </summary>
            FINISH,
            /// <summary>
            /// The failed
            /// </summary>
            FAILED,
            /// <summary>
            /// The lt
            /// </summary>
            LT,
            /// <summary>
            /// The gt
            /// </summary>
            GT,
            /// <summary>
            /// The mod
            /// </summary>
            MOD,
            /// <summary>
            /// The xor
            /// </summary>
            XOR,
            /// <summary>
            /// The sub
            /// </summary>
            SUB,
            /// <summary>
            /// The add
            /// </summary>
            ADD,
            /// <summary>
            /// The amp
            /// </summary>
            AMP,
            /// <summary>
            /// The eq
            /// </summary>
            EQ,
            /// <summary>
            /// The not
            /// </summary>
            NOT,
            /// <summary>
            /// The mult
            /// </summary>
            MULT,
            /// <summary>
            /// The LTLT
            /// </summary>
            LTLT,
            /// <summary>
            /// The GTGT
            /// </summary>
            GTGT,
            /// <summary>
            /// The or
            /// </summary>
            OR,
            /// <summary>
            /// The div
            /// </summary>
            DIV
        }

        /// <summary>
        /// Enum StateIdentifier
        /// </summary>
        public enum StateIdentifier
        {
            /// <summary>
            /// The start
            /// </summary>
            START,
            /// <summary>
            /// The finish
            /// </summary>
            FINISH,
            /// <summary>
            /// The failed
            /// </summary>
            FAILED,
            /// <summary>
            /// The identifier
            /// </summary>
            ID,
        }

        /// <summary>
        /// Enum StateNumber
        /// </summary>
        public enum StateNumber
        {
            /// <summary>
            /// The start
            /// </summary>
            START,
            /// <summary>
            /// The finish
            /// </summary>
            FINISH,
            /// <summary>
            /// The failed
            /// </summary>
            FAILED,
            /// <summary>
            /// The d
            /// </summary>
            D,
        }

        /// <summary>
        /// Enum StateChar
        /// </summary>
        public enum StateChar
        {
            /// <summary>
            /// The start
            /// </summary>
            START,
            /// <summary>
            /// The finish
            /// </summary>
            FINISH,
            /// <summary>
            /// The failed
            /// </summary>
            FAILED,
            /// <summary>
            /// The c
            /// </summary>
            C,
            /// <summary>
            /// The s
            /// </summary>
            S,
            /// <summary>
            /// The so
            /// </summary>
            SO,
            /// <summary>
            /// The soo
            /// </summary>
            SOO,
            /// <summary>
            /// The sooo
            /// </summary>
            SOOO,
            /// <summary>
            /// The sx
            /// </summary>
            SX,
            /// <summary>
            /// The SXH
            /// </summary>
            SXH,
            /// <summary>
            /// The SXHH
            /// </summary>
            SXHH,
        }

        /// <summary>
        /// Enum StateString
        /// </summary>
        public enum StateString
        {
            /// <summary>
            /// The start
            /// </summary>
            START,
            /// <summary>
            /// The finish
            /// </summary>
            FINISH,
            /// <summary>
            /// The failed
            /// </summary>
            FAILED,
            /// <summary>
            /// The l
            /// </summary>
            L,
            /// <summary>
            /// The q
            /// </summary>
            Q,
            /// <summary>
            /// The qq
            /// </summary>
            QQ,
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Scanner"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        public Scanner(String source)
        {
            this.Source = source;

        }

        /// <summary>
        /// Lexes this instance.
        /// </summary>
        /// <returns>IEnumerable&lt;Token&gt;.</returns>
        public IEnumerable<Token> Lex()
        {
            var tokens = new List<Token>();

            while (true)
            {
                while (lexemeBegin < Source.Length && blanks.Contains(Source[lexemeBegin])) lexemeBegin++;
                if (lexemeBegin == Source.Length) break;
                forward = lexemeBegin - 1;

                Token token = null;
                if (letters.Contains(Source[lexemeBegin])) token = GetIdentifier();
                if (digits.Contains(Source[lexemeBegin])) token = GetNumber();
                if (symbols.Contains(Source[lexemeBegin])) token = GetOperator();
                if (charBegin.Contains(Source[lexemeBegin])) token = GetChar();
                if (stringBegin.Contains(Source[lexemeBegin])) token = GetString();

                tokens.Add(token);
                lexemeBegin = forward + 1;
                if (lexemeBegin == Source.Length) break;
            }

            return tokens;
        }

        /// <summary>
        /// Gets the operator.
        /// </summary>
        /// <returns>Token.</returns>
        /// <exception cref="Exception"></exception>
        private Token GetOperator()
        {
            StateOperator state = StateOperator.START;
            TokenOperator token = null;
            char c;
            while (true)
            {
                switch (state)
                {
                    case StateOperator.START:
                        c = NextChar();
                        switch (c)
                        {
                            case '[':
                            case ']':
                            case '(':
                            case ')':
                            case '.':
                            case ',':
                            case '?':
                            case ':':
                            case '~':
                            case ';':
                            case '{':
                            case '}':
                                token = new TokenOperator(val: TokenOperator.Operators[key: $"{c}"]);
                                state = StateOperator.FINISH;
                                break;
                            case '-':
                                state = StateOperator.SUB;
                                break;
                            case '+':
                                state = StateOperator.ADD;
                                break;
                            case '&':
                                state = StateOperator.AMP;
                                break;
                            case '*':
                                state = StateOperator.MULT;
                                break;
                            case '<':
                                state = StateOperator.LT;
                                break;
                            case '>':
                                state = StateOperator.GT;
                                break;
                            case '=':
                                state = StateOperator.EQ;
                                break;
                            case '|':
                                state = StateOperator.OR;
                                break;
                            case '!':
                                state = StateOperator.NOT;
                                break;
                            case '/':
                                state = StateOperator.DIV;
                                break;
                            case '%':
                                state = StateOperator.MOD;
                                break;
                            case '^':
                                state = StateOperator.XOR;
                                break;
                            default:
                                state = StateOperator.FAILED;
                                break;
                        }
                        break;
                    case StateOperator.SUB:
                        c = NextChar();
                        switch (c)
                        {
                            case '>':
                            case '-':
                            case '=':
                                token = new TokenOperator(val: TokenOperator.Operators[key: $"-{c}"]);
                                state = StateOperator.FINISH;
                                break;
                            default:
                                Retract();
                                token = new TokenOperator(val: TokenOperator.Operators[key: $"-"]);
                                state = StateOperator.FINISH;
                                break;
                        }
                        break;
                    case StateOperator.ADD:
                        c = NextChar();
                        switch (c)
                        {
                            case '+':
                            case '=':
                                token = new TokenOperator(val: TokenOperator.Operators[key: $"+{c}"]);
                                state = StateOperator.FINISH;
                                break;
                            default:
                                Retract();
                                token = new TokenOperator(val: TokenOperator.Operators[key: $"+"]);
                                state = StateOperator.FINISH;
                                break;
                        }

                        break;
                    case StateOperator.AMP:
                        c = NextChar();
                        switch (c)
                        {
                            case '&':
                            case '=':
                                token = new TokenOperator(val: TokenOperator.Operators[key: $"&{c}"]);
                                state = StateOperator.FINISH;
                                break;
                            default:
                                Retract();
                                token = new TokenOperator(val: TokenOperator.Operators[key: $"&"]);
                                state = StateOperator.FINISH;
                                break;
                        }

                        break;
                    case StateOperator.LT:
                        c = NextChar();
                        switch (c)
                        {
                            case '=':
                                token = new TokenOperator(val: TokenOperator.Operators[key: $"<{c}"]);
                                state = StateOperator.FINISH;
                                break;
                            case '<':
                                state = StateOperator.LTLT;
                                break;
                            default:
                                Retract();
                                token = new TokenOperator(val: TokenOperator.Operators[key: $"<"]);
                                state = StateOperator.FINISH;
                                break;
                        }
                        break;
                    case StateOperator.GT:
                        c = NextChar();
                        switch (c)
                        {
                            case '=':
                                token = new TokenOperator(val: TokenOperator.Operators[key: $">{c}"]);
                                state = StateOperator.FINISH;
                                break;
                            case '>':
                                state = StateOperator.GTGT;
                                break;
                            default:
                                Retract();
                                token = new TokenOperator(val: TokenOperator.Operators[key: $">"]);
                                state = StateOperator.FINISH;
                                break;
                        }
                        break;
                    case StateOperator.EQ:
                        c = NextChar();
                        switch (c)
                        {
                            case '=':
                                token = new TokenOperator(val: TokenOperator.Operators[key: $"={c}"]);
                                state = StateOperator.FINISH;
                                break;
                            default:
                                Retract();
                                token = new TokenOperator(val: TokenOperator.Operators[key: $"="]);
                                state = StateOperator.FINISH;
                                break;
                        }
                        break;
                    case StateOperator.NOT:
                        c = NextChar();
                        switch (c)
                        {
                            case '=':
                                token = new TokenOperator(val: TokenOperator.Operators[key: $"!{c}"]);
                                state = StateOperator.FINISH;
                                break;
                            default:
                                Retract();
                                token = new TokenOperator(val: TokenOperator.Operators[key: $"!"]);
                                state = StateOperator.FINISH;
                                break;
                        }
                        break;
                    case StateOperator.MOD:
                        c = NextChar();
                        switch (c)
                        {
                            case '=':
                                token = new TokenOperator(val: TokenOperator.Operators[key: $"%{c}"]);
                                state = StateOperator.FINISH;
                                break;
                            default:
                                Retract();
                                token = new TokenOperator(val: TokenOperator.Operators[key: $"%"]);
                                state = StateOperator.FINISH;
                                break;
                        }
                        break;
                    case StateOperator.XOR:
                        c = NextChar();
                        switch (c)
                        {
                            case '=':
                                token = new TokenOperator(val: TokenOperator.Operators[key: $"^{c}"]);
                                state = StateOperator.FINISH;
                                break;
                            default:
                                Retract();
                                token = new TokenOperator(val: TokenOperator.Operators[key: $"^"]);
                                state = StateOperator.FINISH;
                                break;
                        }
                        break;
                    case StateOperator.MULT:
                        c = NextChar();
                        switch (c)
                        {
                            case '=':
                                token = new TokenOperator(val: TokenOperator.Operators[key: $"*{c}"]);
                                state = StateOperator.FINISH;
                                break;
                            default:
                                Retract();
                                token = new TokenOperator(val: TokenOperator.Operators[key: $"*"]);
                                state = StateOperator.FINISH;
                                break;
                        }
                        break;
                    case StateOperator.LTLT:
                        c = NextChar();
                        switch (c)
                        {
                            case '=':
                                token = new TokenOperator(val: TokenOperator.Operators[key: $"<<{c}"]);
                                state = StateOperator.FINISH;
                                break;
                            default:
                                Retract();
                                token = new TokenOperator(val: TokenOperator.Operators[key: $"<<"]);
                                state = StateOperator.FINISH;
                                break;
                        }
                        break;
                    case StateOperator.GTGT:
                        c = NextChar();
                        switch (c)
                        {
                            case '=':
                                token = new TokenOperator(val: TokenOperator.Operators[key: $">>{c}"]);
                                state = StateOperator.FINISH;
                                break;
                            default:
                                Retract();
                                token = new TokenOperator(val: TokenOperator.Operators[key: $">>"]);
                                state = StateOperator.FINISH;
                                break;
                        }
                        break;
                    case StateOperator.OR:
                        c = NextChar();
                        switch (c)
                        {
                            case '|':
                            case '=':
                                token = new TokenOperator(val: TokenOperator.Operators[key: $"|{c}"]);
                                state = StateOperator.FINISH;
                                break;
                            default:
                                Retract();
                                token = new TokenOperator(val: TokenOperator.Operators[key: $"|"]);
                                state = StateOperator.FINISH;
                                break;
                        }
                        break;
                    case StateOperator.DIV:
                        c = NextChar();
                        switch (c)
                        {
                            case '=':
                                token = new TokenOperator(val: TokenOperator.Operators[key: $"/{c}"]);
                                state = StateOperator.FINISH;
                                break;
                            default:
                                Retract();
                                token = new TokenOperator(val: TokenOperator.Operators[key: $"/"]);
                                state = StateOperator.FINISH;
                                break;
                        }
                        break;
                    case StateOperator.FINISH:
                        return token;
                    case StateOperator.FAILED:
                        throw new Exception();
                }
            }
            
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <returns>Token.</returns>
        private Token GetIdentifier()
        {
            StateIdentifier state = StateIdentifier.START;
            String identifier = "";
            Char c;
            HashSet<Char> legalChars = new HashSet<Char>("_0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ");
            while (true)
            {
                switch (state)
                {
                    case StateIdentifier.START:
                        c = NextChar();
                        identifier += c;
                        state = StateIdentifier.ID;
                        break;
                    case StateIdentifier.ID:
                        c = NextChar();
                        if (legalChars.Contains(c))
                        {
                            identifier += c;
                            state = StateIdentifier.ID;
                        }
                        else
                        {
                            Retract();
                            state = StateIdentifier.FINISH;
                        }
                        break;
                    case StateIdentifier.FINISH:
                        if (TokenKeyword.Keywords.ContainsKey(identifier))
                            return new TokenKeyword(val: TokenKeyword.Keywords[identifier]);
                        else
                            return new TokenIdentifier(val: identifier);
                }
            }
            
        }

        /// <summary>
        /// Gets the number.
        /// </summary>
        /// <returns>Token.</returns>
        private Token GetNumber()
        {
            Char c;
            StateNumber state = StateNumber.START;
            Int64 number = 0;
            Int32 digit;
            while (true)
            {
                switch (state)
                {
                    case StateNumber.START:
                        c = NextChar();
                        digit = Convert.ToInt32(c) - 0x30;
                        number *= 10;
                        number += digit;
                        state = StateNumber.D;
                        break;
                    case StateNumber.D:
                        c = NextChar();
                        if (Char.IsDigit(c))
                        {
                            digit = Convert.ToInt32(c) - 0x30;
                            
                            number *= 10;
                            number += digit;
                            state = StateNumber.D;
                        }
                        else
                        {
                            Retract();
                            state = StateNumber.FINISH;
                        }
                        break;
                    case StateNumber.FINISH:
                        return new TokenInt(val: number);
                }
            }
        }

        /// <summary>
        /// Gets the character.
        /// </summary>
        /// <returns>Token.</returns>
        /// <exception cref="Exception"></exception>
        private Token GetChar()
        {
            StateChar state = StateChar.START;
            Char c = '\0';
            NextChar();
            var invalidChars = new HashSet<Char>("\'\n");
            string escapeChars = @"abfnrtv'""\";
            string correspondingEscapeChars = "\a\b\f\n\r\t\v\'\"\\";
            TokenChar result = null;
            while (true)
            {
                switch (state)
                {
                    case StateChar.START:
                        c = NextChar();
                        switch (c)
                        {
                            case '\\':
                                state = StateChar.S;
                                break;
                            default:
                                if (invalidChars.Contains(c))
                                {
                                    state = StateChar.FAILED;
                                }
                                else
                                {
                                    state = StateChar.C;
                                }
                                break;
                        }
                        
                        break;
                    case StateChar.C:
                        result = new TokenChar(val: c);
                        c = NextChar();
                        if (c == '\'')
                        {
                            state = StateChar.FINISH;
                        }
                        else
                        {
                            state = StateChar.FAILED;
                        }
                        break;
                    case StateChar.S:
                        c = NextChar();
                        if (escapeChars.Contains(c))
                        {
                            c = correspondingEscapeChars[escapeChars.IndexOf(c)];
                            state = StateChar.C;
                        }
                        else
                        {
                            state = StateChar.FAILED;
                        }
                        break;
                    case StateChar.FINISH:
                        return result;
                    case StateChar.FAILED:
                        throw new Exception();

                }
            }
        }

        /// <summary>
        /// Gets the string.
        /// </summary>
        /// <returns>Token.</returns>
        private Token GetString()
        {
            //TODO
            StateString state = StateString.START;
            Char c;
            return new TokenString("string");
        }

        /// <summary>
        /// Retracts this instance.
        /// </summary>
        private void Retract()
        {
            forward--;
        }

        /// <summary>
        /// Nexts the character.
        /// </summary>
        /// <returns>Char.</returns>
        private Char NextChar()
        {
            forward++;
            return Source[forward];
        }

        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <value>The source.</value>
        public String Source { get; }

        /// <summary>
        /// The blanks
        /// </summary>
        private HashSet<Char> blanks = new HashSet<Char>("\0\t\r\n ");
        /// <summary>
        /// The letters
        /// </summary>
        private HashSet<Char> letters = new HashSet<Char>("_abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ");
        /// <summary>
        /// The digits
        /// </summary>
        private HashSet<Char> digits = new HashSet<Char>("0123456789");
        /// <summary>
        /// The symbols
        /// </summary>
        private HashSet<Char> symbols = new HashSet<Char>("~!%^&*()+-={}[]|:;<>,.?/");
        /// <summary>
        /// The character begin
        /// </summary>
        private HashSet<Char> charBegin = new HashSet<Char>("'");
        /// <summary>
        /// The string begin
        /// </summary>
        private HashSet<Char> stringBegin = new HashSet<Char>("\"");
        /// <summary>
        /// The lexeme begin
        /// </summary>
        private Int32 lexemeBegin = 0;
        /// <summary>
        /// The forward
        /// </summary>
        private Int32 forward = 0;
    }
}
