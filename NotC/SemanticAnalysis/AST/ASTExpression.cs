using System;
using System.Collections.Generic;
using System.Text;
using NotC.SyntaxAnalysis;
using NotC.LexicalAnalysis;

namespace NotC.AST {
    public abstract class ASTExpression : ASTNode
    {
        public Type Type;
    }
}
