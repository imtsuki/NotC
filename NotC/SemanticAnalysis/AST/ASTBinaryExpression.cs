using System;
using System.Collections.Generic;
using System.Text;
using NotC.LexicalAnalysis;

namespace NotC.AST
{
    public sealed class ASTBinaryExpression : ASTExpression
    {
        public ASTExpression Left { get; set; }
        public ASTExpression Right { get; set; }
        public ASTBinaryExpression(ASTExpression left, ASTExpression right)
        {
            Left = left;
            Right = right;
        }
    }
}

