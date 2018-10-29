using System.Collections.Generic;
using NotC.LexicalAnalysis;

namespace NotC.SyntaxAnalysis {
    public sealed class SyntaxBinaryExpression : SyntaxExpression {
        public SyntaxExpression Left { get; }
        public Token Operator { get; }
        public SyntaxExpression Right { get; }

        public SyntaxBinaryExpression(SyntaxExpression left, Token @operator, SyntaxExpression right) {
            Left = left;
            Operator = @operator;
            Right = right;
        }

        public override IEnumerable<SyntaxNode> Children() {
            yield return Left;
            yield return Operator;
            yield return Right;
        }
    }
}