using System;

namespace NotC.AST
{
    public abstract class ASTExpression : ASTNode
    {
        public abstract Type Type { get; }
    }
}
