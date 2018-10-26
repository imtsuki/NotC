using System;
using System.Collections.Generic;
using System.Linq;
using NotC.SyntaxAnalysis;

namespace NotC.LexicalAnalysis
{
    public abstract class Token : SyntaxNode
    {
        public override String ToString()
        {
            return Kind.ToString();
        }
        public int Position { get; }
        public int Length { get; }
        public abstract TokenKind Kind { get; }

        public override IEnumerable<SyntaxNode> Children() {
            return Enumerable.Empty<SyntaxNode>();
        }

        public Token(int position, int length) {
            Position = position;
            Length = length;
        }
    }
}
