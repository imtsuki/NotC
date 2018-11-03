using System;

namespace NotC.AST
{
    public sealed class ASTUnaryOperator : ASTNode {
        public override ASTNodeKind Kind => ASTNodeKind.UnaryOperator;
        public Type Type { get; }
    }

}