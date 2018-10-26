using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotC.LexicalAnalysis
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

        public IEnumerable<Token> Scan()
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
                char c = Next();
                if (!Char.IsPunctuation(c) && !Char.IsSymbol(c)) {
                    Retract();
                    break;
                }
                length++;
            }
            int fullLength = length;
            string op = Source.Substring(lexemeBegin, length);
            while (length > 0) {
                if (TokenOperator.Operators.ContainsKey(op.Substring(0, length))) {
                    forward = lexemeBegin + length - 1;
                    return new TokenOperator(op.Substring(0, length), lexemeBegin, length);
                }
                length--;
            }
            ErrorMessage.Add($"Cannot Parse Operator {op}. ");
            return new TokenError(lexemeBegin, fullLength);
        }

        private Token GetIdentifier()
        {
            int length = 0;
            while(true)
            {
                Char c = Next();
                if (Char.IsPunctuation(c) || Char.IsSymbol(c) || Char.IsWhiteSpace(c)) {
                    Retract();
                    break;
                }
                length++;
            }
            string identifier = Source.Substring(lexemeBegin, length);
            if (TokenKeyword.Keywords.ContainsKey(identifier))
                return new TokenKeyword(TokenKeyword.Keywords[identifier], lexemeBegin, length);
            else
                return new TokenIdentifier(identifier, lexemeBegin, length);
        }

        private Token GetNumber()
        {
            Char c;
            StateNumber state = StateNumber.START;
            Int64 number = 0;
            Int32 digit;
            int length = 0;
            while (true)
            {
                switch (state)
                {
                    case StateNumber.START:
                        c = Next();
                        digit = Convert.ToInt32(c) - 0x30;
                        number *= 10;
                        number += digit;
                        state = StateNumber.D;
                        break;
                    case StateNumber.D:
                        c = Next();
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
                            length--;
                            state = StateNumber.FINISH;
                        }
                        break;
                    case StateNumber.FINISH:
                        return new TokenInt(number, lexemeBegin, length);
                }
                length++;
            }
        }

        private Token GetChar()
        {
            StateChar state = StateChar.START;
            Char c = '\0';
            Next();
            var invalidChars = new HashSet<Char>("\'\n");
            string escapeChars = @"abfnrtv'""\";
            string correspondingEscapeChars = "\a\b\f\n\r\t\v\'\"\\";
            TokenChar result = null;
            int length = 0;
            while (true)
            {
                switch (state)
                {
                    case StateChar.START:
                        c = Next();
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
                        result = new TokenChar(c, lexemeBegin, length + 2);
                        c = Next();
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
                        c = Next();
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
                        ErrorMessage.Add($"Character Parse failed when meeting '{c}'. ");
                        return new TokenError(lexemeBegin, length + 1);
                }
                length++;
            }
        }

        private Token GetString()
        {
            int length = 0;
            Next();
            while(true)
            {
                Char c = Next();
                if (c == '"')
                    break;
                if (c == '\n') {
                    ErrorMessage.Add("Unexpected Line Ending While Parsing String. ");
                    return new TokenError(lexemeBegin, length + 1);
                }
                length++;
            }
            string str = Source.Substring(lexemeBegin + 1, length);
            return new TokenString(str, lexemeBegin, length + 2);
        }

        private void Retract()
        {
            forward--;
        }

        private Char Next()
        {
            forward++;
            return Source[forward];
        }

        public String Source { get; }

        public List<string> ErrorMessage = new List<string>();

        private Int32 lexemeBegin = 0;
        private Int32 forward = 0;
    }
}
