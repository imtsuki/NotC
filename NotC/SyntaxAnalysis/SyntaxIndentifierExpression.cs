using System.Collections.Generic;
using NotC.LexicalAnalysis;
namespace NotC.SyntaxAnalysis {
    public sealed class SyntaxIdentifierExpression : SyntaxExpression {
        public SyntaxIdentifierExpression(TokenIdentifier identifier) {
            Identifier = identifier;
        }

        public TokenIdentifier Identifier { get; }

        public override IEnumerable<SyntaxNode> Children() {
            yield return Identifier;
        }
    }
}