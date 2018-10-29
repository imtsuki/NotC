using System;

namespace NotC.AST
{
    public sealed class ASTBinaryOperator : ASTNode {
        public override ASTNodeKind Kind => ASTNodeKind.BinaryOperator;
        public Type Type { get; }
    }

}