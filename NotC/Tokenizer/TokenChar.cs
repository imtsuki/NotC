using System;
using System.Collections.Generic;
using System.Text;

namespace C.Tokenizer
{
    public class TokenChar : Token
    {
        public TokenChar(Char val) => this.Val = val;

        public override TokenKind Kind { get; } = TokenKind.CHAR;

        public Char Val { get; }

        public override String ToString()
        {
            return $"{this.Kind}: '{this.Val}'";
        }
    }
}
