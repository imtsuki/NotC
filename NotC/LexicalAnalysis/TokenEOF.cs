using System;
using System.Collections.Generic;
using System.Text;

namespace NotC.LexicalAnalysis
{
    public sealed class TokenEOF : Token
    {
        public TokenEOF() : base(-1, -1) { }
        public override TokenKind Kind { get; } = TokenKind.EOF;
    }
}
