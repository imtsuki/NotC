using System;

namespace NotC.AST
{
    public sealed class ASTBinaryExpression : ASTExpression {
        public override ASTNodeKind Kind => ASTNodeKind.BinaryExpression;
        public override Type Type => Operator.Type;
        public ASTExpression Left { get; }
        public ASTBinaryOperator Operator { get; }
        public ASTExpression Right { get; }
        public ASTBinaryExpression(ASTExpression left, ASTExpression right) {
            Left = left;
            Right = right;
        }
    }
}

