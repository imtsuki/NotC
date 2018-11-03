using System.Collections.Generic;
using NotC.LexicalAnalysis;

namespace NotC.SyntaxAnalysis {
    public sealed class SyntaxUnaryExpression : SyntaxExpression {
        public Token Operator { get; }

        public SyntaxExpression Operand { get; }

        public SyntaxUnaryExpression(Token @operator, SyntaxExpression operand) {
            Operator = @operator;
            Operand = operand;
        }

        public override IEnumerable<SyntaxNode> Children() {
            yield return Operator;
            yield return Operand;
        }
    }
}