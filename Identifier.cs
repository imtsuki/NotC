using System;

namespace C
{
    public class TokenIdentifier : Token
    {
        public TokenIdentifier(String val)
        {
            this.Val = val;
        }
        public override TokenKind Kind { get; } = TokenKind.IDENTIFIER;
        public String Val { get; }
        public override string ToString()
        {
            return this.Kind + ": " + this.Val;
        }
    }
}