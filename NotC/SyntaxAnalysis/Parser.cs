using System;
using System.Collections.Generic;
using System.Linq;
using NotC.LexicalAnalysis;
using NotC.AST;

namespace NotC.SyntaxAnalysis
{
    public class Parser
    {
        public List<string> ErrorMessage = new List<string>();

        public Parser(string source) {
            var scanner = new Scanner(source);
            var tokens = scanner.Scan();
            foreach (var token in tokens) {
                if (token.Kind != TokenKind.ERROR) {
                    Tokens.Add(token);
                }
            }
            ErrorMessage.AddRange(scanner.ErrorMessage);
        }

        private Token Peek(int offset) {
            if (Position + offset >= Tokens.Count()) {
                return Tokens.Last();
            }
            return Tokens[Position + offset];
        }

        public SyntaxNode Parse()
        {
            var expression = ParseExpression();
            return expression;
        }

         private SyntaxExpression ParseExpression() {
             return ParseBinaryExpression();
        }

        private SyntaxExpression ParseBinaryExpression(int parentOperatorPrecedence = 0) {
            return ParseFactorExpression();
        }

        private SyntaxExpression ParseFactorExpression() {
            ASTExpression result = null;
            switch (CurrentToken.Kind)
            {
                case TokenKind.OPERATOR:
                    var left = Match("(");
                    var expression = ParseExpression();
                    var right = Match(")");
                    return new SyntaxParenthesizedExpression((TokenOperator)left, expression, (TokenOperator)right);
                case TokenKind.INT:
                    result = new IntNumber((TokenInt)CurrentToken);
                    Match(TokenKind.INT);
                    break;
                case TokenKind.IDENTIFIER:
                    Match(TokenKind.IDENTIFIER);
                    break;
                
                default:
                    ErrorMessage.Add("Syntax Error");
                    break;
            }
            return result;
        }


        private List<Token> Tokens { get; set; } = new List<Token>();
        private Int32 Position = 0;
        private Token CurrentToken => Peek(0);
        private Token NextToken()
        {
            var token = CurrentToken;
            Position++;
            return token;
        }

        private Token Match(object term)
        {
            if (term.GetType().Equals(typeof(KeywordVal)))
            {
                if (CurrentToken.Kind == TokenKind.KEYWORD &&
                    ((TokenKeyword)CurrentToken).Val == (KeywordVal)term)
                    return NextToken();
            }
            else if (term.GetType().Equals(typeof(string)))
            {
                if (CurrentToken.Kind == TokenKind.OPERATOR &&
                    ((TokenOperator)CurrentToken).Val == (string)term)
                    return NextToken();
            }
            else if (term.GetType().Equals(typeof(TokenKind)))
            {
                if (CurrentToken.Kind == (TokenKind)term)
                    return NextToken();
            }
            ErrorMessage.Add($"Unexpected {CurrentToken}, Expected {term}");
            // Since a TokenError token will break the process of generating AST,
            // further improvement is needed here.
            return new TokenError(CurrentToken.Position, CurrentToken.Length);
        }
    }
}
