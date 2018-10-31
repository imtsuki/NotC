using System;

namespace NotC.AST
{
    public sealed class ASTUnaryExpression : ASTExpression {
        public override ASTNodeKind Kind => ASTNodeKind.UnaryExpression;
        public override Type Type => Operator.Type;
        public ASTUnaryOperator Operator { get; }
        public ASTExpression Operand { get; }

        public ASTUnaryExpression(ASTUnaryOperator @operator, ASTExpression operand) {
            Operator = @Operator;
            Operand = operand;
        }
    }
}

