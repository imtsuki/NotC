using System;
using System.Collections.Generic;
using System.Text;

namespace NotC.LexicalAnalysis
{
    public sealed class TokenError : Token
    {
        public override TokenKind Kind { get; } = TokenKind.ERROR;
    }
}
