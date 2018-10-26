using System.Collections.Generic;
using NotC.LexicalAnalysis;
namespace NotC.SyntaxAnalysis {
    public sealed class SyntaxLiteralExpression : SyntaxExpression {
        public Token LiteralToken { get; }
        public override IEnumerable<SyntaxNode> Children()
        {
            yield return LiteralToken;
        }
    }
}