using System;
using System.Collections.Generic;
using System.Text;

namespace NotC.LexicalAnalysis
{
    public sealed class TokenInt : Token
    {
        public TokenInt(Int64 val, int position, int length) : base(position, length) => Val = val;

        public override TokenKind Kind { get; } = TokenKind.INT;

        public Int64 Val { get; }

        public override string ToString() => $"{this.Kind}: {this.Val}";
    }
}
