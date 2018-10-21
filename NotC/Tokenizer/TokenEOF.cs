using System;
using System.Collections.Generic;
using System.Text;

namespace C.Tokenizer
{
    class TokenEOF : Token
    {
        public override TokenKind Kind { get; } = TokenKind.EOF;
    }
}
