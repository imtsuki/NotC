using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotC.Tokenizer
{
    public class Scanner
    {
        public enum StateNumber
        {
            START,
            FINISH,
            FAILED,
            D,
        }

        public enum StateChar
        {
            START,
            FINISH,
            FAILED,
            C,
            S,
            SO,
            SOO,
            SOOO,
            SX,
            SXH,
            SXHH,
        }

        public Scanner(String source)
        {
            this.Source = source;
            if (Source.Last() != '\n')
                Source += "\n";

        }

        public IList<Token> Lex()
        {
            var tokens = new List<Token>();

            while (true)
            {
                while (lexemeBegin < Source.Length && Char.IsWhiteSpace(Source[lexemeBegin])) lexemeBegin++;
                if (lexemeBegin == Source.Length) break;
                forward = lexemeBegin - 1;

                Token token = null;
                if (Char.IsDigit(Source[lexemeBegin]))
                    token = GetNumber();
                else if (Char.IsPunctuation(Source[lexemeBegin]) || Char.IsSymbol(Source[lexemeBegin])) {
                    if (Source[lexemeBegin] == '\'')
                        token = GetChar();
                    else if (Source[lexemeBegin] == '"')
                        token = GetString();
                    else if (Source[lexemeBegin] != '_')
                        token = GetOperator();
                }
                else
                    token = GetIdentifier();

                tokens.Add(token);
                lexemeBegin = forward + 1;
                if (lexemeBegin == Source.Length) break;
            }
            tokens.Add(new TokenEOF());
            return tokens;
        }

        private Token GetOperator()
        {
            int length = 0;
            while (true) {
                char c = NextChar();
                if (!Char.IsPunctuation(c) && !Char.IsSymbol(c)) {
                    Retract();
                    break;
                }
                length++;
            }
            string op = Source.Substring(lexemeBegin, length);
            while (length > 0) {
                if (TokenOperator.Operators.ContainsKey(op.Substring(0, length))) {
                    forward = lexemeBegin + length - 1;
                    return new TokenOperator(TokenOperator.Operators[op.Substring(0, length)]);
                }
                length--;
            }
            LexErrors.Add($"Cannot Parse Operator {op}. ");
            return new TokenError();
        }

        private Token GetIdentifier()
        {
            int length = 0;
            while(true)
            {
                Char c = NextChar();
                if (Char.IsPunctuation(c) || Char.IsSymbol(c) || Char.IsWhiteSpace(c)) {
                    Retract();
                    break;
                }
                length++;
            }
            string identifier = Source.Substring(lexemeBegin, length);
            if (TokenKeyword.Keywords.ContainsKey(identifier))
                return new TokenKeyword(val: TokenKeyword.Keywords[identifier]);
            else
                return new TokenIdentifier(val: identifier);
        }

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

        private Token GetString()
        {
            int length = 0;
            NextChar();
            while(true)
            {
                Char c = NextChar();
                if (c == '"')
                    break;
                if (c == '\n') {
                    LexErrors.Add("Unexpected Line Ending While Parsing String. ");
                    return new TokenError();
                }
                length++;
            }
            string str = Source.Substring(lexemeBegin + 1, length);
            return new TokenString(str);
        }

        private void Retract()
        {
            forward--;
        }

        private Char NextChar()
        {
            forward++;
            return Source[forward];
        }

        public String Source { get; }

        public List<string> LexErrors = new List<string>();

        private Int32 lexemeBegin = 0;
        private Int32 forward = 0;
    }
}
