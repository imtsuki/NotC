using System.Collections.Generic;
using NotC.LexicalAnalysis;
namespace NotC.SyntaxAnalysis {
    public sealed class SyntaxParenthesizedExpression : SyntaxExpression {
        private Token left;
        private Token right;

        public SyntaxParenthesizedExpression(TokenOperator left, SyntaxExpression expression, TokenOperator right)
        {
            LeftParenthesizedToken = left;
            Expression = expression;
            RightParenthesizedToken = right;
        }

        public TokenOperator LeftParenthesizedToken { get; }
        public SyntaxExpression Expression { get; }
        public TokenOperator RightParenthesizedToken { get; }

        public override IEnumerable<SyntaxNode> Children() {
            yield return LeftParenthesizedToken;
            yield return Expression;
            yield return RightParenthesizedToken;
        }
    }
}