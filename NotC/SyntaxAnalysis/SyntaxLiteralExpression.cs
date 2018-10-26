using System.Collections.Generic;
using NotC.LexicalAnalysis;
namespace NotC.SyntaxAnalysis {
    public sealed class SyntaxLiteralExpression : SyntaxExpression {
        public SyntaxLiteralExpression(TokenInt number) {
            LiteralToken = number;
        }

        public TokenInt LiteralToken { get; }
        public override IEnumerable<SyntaxNode> Children()
        {
            yield return LiteralToken;
        }
    }
}