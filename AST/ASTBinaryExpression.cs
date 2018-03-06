using System;
using System.Collections.Generic;
using System.Text;
using C.Tokenizer;

namespace C.AST
{
    class ASTBinaryExpression : ASTExpression
    {
        private Tokenizer.TokenOperator @operator;
        private ASTExpression rHS;
        private ASTExpression lHS;

        public TokenOperator Operator { get => @operator; set => @operator = value; }
        public ASTExpression LHS { get => lHS; set => lHS = value; }
        public ASTExpression RHS { get => rHS; set => rHS = value; }

        public ASTBinaryExpression(TokenOperator @operator, ASTExpression lHS, ASTExpression rHS)
        {
            Operator = @operator;
            LHS = lHS;
            RHS = rHS;
        }
    }
}
