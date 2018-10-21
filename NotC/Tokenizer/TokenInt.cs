using System;
using System.Collections.Generic;
using System.Text;

namespace C.Tokenizer
{
    public class TokenInt : Token
    {
        public TokenInt(Int64 val) => this.Val = val;

        public override TokenKind Kind { get; } = TokenKind.INT;

        public Int64 Val { get; }

        public override String ToString() => $"{this.Kind}: {this.Val}";
    }
}
