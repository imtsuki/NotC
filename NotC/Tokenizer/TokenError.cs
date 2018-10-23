using System;
using System.Collections.Generic;
using System.Text;

namespace NotC.Tokenizer
{
    public sealed class TokenError : Token
    {
        public override TokenKind Kind { get; } = TokenKind.ERROR;
    }
}
