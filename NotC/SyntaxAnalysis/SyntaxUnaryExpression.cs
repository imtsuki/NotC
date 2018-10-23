using System.Collections.Generic;
using NotC.LexicalAnalysis;

namespace NotC.SyntaxAnalysis {
    public abstract class SyntaxUnaryExpression : SyntaxExpression {
        public TokenOperator Operator { get; }

        public SyntaxExpression Operand { get; }

        public SyntaxUnaryExpression(TokenOperator @operator, SyntaxExpression operand) {
            Operator = @operator;
            Operand = operand;
        }

        public override IEnumerable<SyntaxNode> GetChildren() {
            yield return Operator;
            yield return Operand;
        }
    }
}