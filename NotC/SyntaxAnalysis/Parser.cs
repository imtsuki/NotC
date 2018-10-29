using System;
using System.Collections.Generic;
using System.Linq;
using NotC.LexicalAnalysis;
using NotC.AST;

namespace NotC.SyntaxAnalysis
{
    public sealed class Parser
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
            SyntaxExpression left;
            left = ParseFactorExpression();
            while (true) {
                var precedence = CurrentToken.GetOperatorPrecedence();
                if (precedence == 0 || precedence <= parentOperatorPrecedence)
                    break;
                var operatorToken = NextToken();
                var right = ParseBinaryExpression(precedence);
                left = new SyntaxBinaryExpression(left, operatorToken, right);
            }
            return left;
        }

        private SyntaxExpression ParseFactorExpression() {
            switch (CurrentToken.Kind)
            {
                case TokenKind.OPERATOR:
                    var left = MatchOperator("(");
                    var expression = ParseExpression();
                    var right = MatchOperator(")");
                    return new SyntaxParenthesizedExpression(left, expression, right);
                case TokenKind.IDENTIFIER:
                    var identifier = NextToken();
                    return new SyntaxIdentifierExpression(identifier);
                default:
                    var number = Match(TokenKind.INT);
                    return new SyntaxLiteralExpression(number);
            }
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

        private Token Match(TokenKind kind)
        {
            if (CurrentToken.Kind == kind)
                return NextToken();
            ErrorMessage.Add($"Unexpected {CurrentToken}, Expected {kind}");
            return Token.GetErrorToken(CurrentToken.Position, CurrentToken.Length);
        }

        private Token MatchOperator(string val) {
            if (CurrentToken.Kind == TokenKind.OPERATOR &&
                (string)CurrentToken.Val == val) {
                    return NextToken();
                }
            ErrorMessage.Add($"Unexpected {CurrentToken}, Expected operator '{val}'. ");
            return Token.GetOperatorToken(val, CurrentToken.Position, CurrentToken.Length);
        }

        private Token MatchKeyword(KeywordVal val) {
            if (CurrentToken.Kind == TokenKind.KEYWORD &&
                (KeywordVal)CurrentToken.Val == val) {
                    return NextToken();
                }
            ErrorMessage.Add($"Unexpected {CurrentToken}, Expected keyword '{val}'. ");
            return Token.GetKeywordToken(val, CurrentToken.Position, CurrentToken.Length);
        }
    }
}
