using System;
using System.Collections.Generic;
using System.Text;

namespace NotC.LexicalAnalysis
{
    public sealed class TokenError : Token
    {
        public TokenError(int position, int length) : base(position, length) { }
        public override TokenKind Kind { get; } = TokenKind.ERROR;
    }
}
