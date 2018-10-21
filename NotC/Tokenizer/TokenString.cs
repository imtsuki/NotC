using System;
using System.Collections.Generic;
using System.Text;

namespace C.Tokenizer
{
    public class TokenString : Token
    {
        public TokenString(String val)
        {
            this.Val = val;
        }

        public override TokenKind Kind { get; } = TokenKind.STRING;

        public String Val { get; }

        public override String ToString()
        {
            return $"{this.Kind}: \"{this.Val}\"";
        }
    }
}
