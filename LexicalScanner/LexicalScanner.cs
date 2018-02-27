using System;
using System.Collections.Generic;
using System.Text;

namespace C
{
    public class LexicalScanner
    {

        public enum StateOperator
        {
            START,
            FINISH,
            FAILED,
            LT,
            GT,
            MOD,
            XOR,
            SUB,
            ADD,
            AMP,
            EQ,
            NOT,
            MULT,
            LTLT,
            GTGT,
            OR,
            DIV
        }

        public enum StateIdentifier
        {
            START,
            FINISH,
            FAILED,
            ID,
        }

        public LexicalScanner(String source)
        {
            this.Source = source;

        }

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

        private Token GetNumber()
        {
            Char c;
            return new TokenInt(0);
        }

        private Token GetChar()
        {
            return new TokenChar('c');
        }

        private Token GetString()
        {
            return new TokenString("string");
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

        private HashSet<Char> blanks = new HashSet<Char>("\0\t\r\n ");
        private HashSet<Char> letters = new HashSet<Char>("_abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ");
        private HashSet<Char> digits = new HashSet<Char>("0123456789");
        private HashSet<Char> symbols = new HashSet<Char>("~!%^&*()+-={}[]|:;<>,.?/");
        private HashSet<Char> charBegin = new HashSet<Char>("'");
        private HashSet<Char> stringBegin = new HashSet<Char>("\"");
        private Int32 lexemeBegin = 0;
        private Int32 forward = 0;
    }
}
