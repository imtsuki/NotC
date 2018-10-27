using System.Collections.Generic;
using NotC.LexicalAnalysis;
namespace NotC.SyntaxAnalysis {
    public sealed class SyntaxIdentifierExpression : SyntaxExpression {
        public SyntaxIdentifierExpression(Token identifier) {
            Identifier = identifier;
        }

        public Token Identifier { get; }

        public override IEnumerable<SyntaxNode> Children() {
            yield return Identifier;
        }
    }
}