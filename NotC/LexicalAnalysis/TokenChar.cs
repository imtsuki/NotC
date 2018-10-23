using System;
using System.Collections.Generic;
using System.Text;

namespace NotC.LexicalAnalysis
{
    public sealed class TokenChar : Token
    {
        public TokenChar(char val) => this.Val = val;

        public override TokenKind Kind { get; } = TokenKind.CHAR;

        public char Val { get; }

        public override String ToString() => $"{this.Kind}: '{this.Val}'";
    }
}
