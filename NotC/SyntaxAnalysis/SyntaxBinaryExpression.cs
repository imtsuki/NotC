using System.Collections.Generic;
using NotC.LexicalAnalysis;

namespace NotC.SyntaxAnalysis {
    public abstract class SyntaxBinaryExpression : SyntaxExpression {
        public SyntaxExpression Left { get; }
        public TokenOperator Operator { get; }
        public SyntaxExpression Right { get; }

        public SyntaxBinaryExpression(SyntaxExpression left, TokenOperator @operator, SyntaxExpression right) {
            Left = left;
            Operator = @operator;
            Right = right;
        }

        public override IEnumerable<SyntaxNode> GetChildren() {
            yield return Left;
            yield return Operator;
            yield return Right;
        }
    }
}