using System;
using System.Collections.Generic;
using System.Text;

namespace NotC.LexicalAnalysis
{
    public sealed class TokenString : Token
    {
        public TokenString(string val, int position, int length) : base(position, length) => Val = val;

        public override TokenKind Kind { get; } = TokenKind.STRING;

        public string Val { get; }

        public override string ToString() => $"{this.Kind}: \"{this.Val}\"";
    }
}
