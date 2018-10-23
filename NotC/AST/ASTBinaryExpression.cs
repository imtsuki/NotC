using System;
using System.Collections.Generic;
using System.Text;
using NotC.LexicalAnalysis;

namespace NotC.AST
{
    public class ASTBinaryExpression : ASTExpression
    {
        public ASTExpression Left { get; set; }
        public ASTExpression Right { get; set; }
        public ASTBinaryExpression(ASTExpression left, ASTExpression right)
        {
            Left = left;
            Right = right;
        }
    }
    public class Add : ASTBinaryExpression
    {
        public Add(ASTExpression left, ASTExpression right) : base(left, right)
        {

        }

        public override string ToString()
        {
            return $"({Left.ToString()} + {Right.ToString()})";
        }
    }

    public class Sub : ASTBinaryExpression
    {
        public Sub(ASTExpression left, ASTExpression right) : base(left, right)
        {

        }

        public override string ToString()
        {
            return $"({Left.ToString()} - {Right.ToString()})";
        }
    }
    public class Mult : ASTBinaryExpression
    {
        public Mult(ASTExpression left, ASTExpression right) : base(left, right)
        {

        }

        public override string ToString()
        {
            return $"({Left.ToString()} * {Right.ToString()})";
        }
    }

    public class Div : ASTBinaryExpression
    {
        public Div(ASTExpression left, ASTExpression right) : base(left, right)
        {

        }

        public override string ToString()
        {
            return $"({Left.ToString()} / {Right.ToString()})";
        }
    }

    public class Assign : ASTBinaryExpression
    {
        public Assign(ASTExpression left, ASTExpression right) : base(left, right)
        {

        }

        public override string ToString()
        {
            return $"({Left.ToString()} = {Right.ToString()})";
        }
    }
}

