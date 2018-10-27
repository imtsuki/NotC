using System.Collections.Generic;
using NotC.LexicalAnalysis;
namespace NotC.SyntaxAnalysis {
    public sealed class SyntaxParenthesizedExpression : SyntaxExpression {
        public SyntaxParenthesizedExpression(Token left, SyntaxExpression expression, Token right) {
            LeftParenthesizedToken = left;
            Expression = expression;
            RightParenthesizedToken = right;
        }

        public Token LeftParenthesizedToken { get; }
        public SyntaxExpression Expression { get; }
        public Token RightParenthesizedToken { get; }

        public override IEnumerable<SyntaxNode> Children() {
            yield return LeftParenthesizedToken;
            yield return Expression;
            yield return RightParenthesizedToken;
        }
    }
}