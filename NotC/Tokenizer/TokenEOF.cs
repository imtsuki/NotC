using System;
using System.Collections.Generic;
using System.Text;

namespace NotC.Tokenizer
{
    class TokenEOF : Token
    {
        public override TokenKind Kind { get; } = TokenKind.EOF;
    }
}
