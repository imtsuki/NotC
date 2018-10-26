using System;
using System.Collections.Generic;
using System.Text;

namespace NotC.LexicalAnalysis
{
    public sealed class TokenChar : Token
    {
        public TokenChar(char val, int position, int length) : base(position, length) => Val = val;
        public override TokenKind Kind { get; } = TokenKind.CHAR;

        public char Val { get; }

        public override string ToString() => $"{this.Kind}: '{this.Val}'";
    }
}
