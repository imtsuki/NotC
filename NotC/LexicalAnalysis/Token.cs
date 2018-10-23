using System;
using System.Collections.Generic;
using System.Linq;
using NotC.SyntaxAnalysis;

namespace NotC.LexicalAnalysis
{
    public enum TokenKind
    {
        NONE,
        FLOAT,
        INT,
        CHAR,
        STRING,
        IDENTIFIER,
        KEYWORD,
        OPERATOR,
        EOF,
        ERROR
    }

    public abstract class Token : SyntaxNode
    {
        public override String ToString()
        {
            return Kind.ToString();
        }
        int position;
        public abstract TokenKind Kind { get; }

        public override IEnumerable<SyntaxNode> GetChildren() {
            return Enumerable.Empty<SyntaxNode>();
        }
    }
}
