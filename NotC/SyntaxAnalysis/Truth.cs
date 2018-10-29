using NotC.LexicalAnalysis;

namespace NotC.SyntaxAnalysis {
    internal static class Truth {
        public static int GetOperatorPrecedence(this Token operatorToken) {
            if (operatorToken.Kind != TokenKind.OPERATOR)
                return 0;
            var @operator = (string)operatorToken.Val;
            switch (@operator) {
                case "*":
                case "/":
                    return 2;
                case "+":
                case "-":
                    return 1;
                default:
                    return 0;
            }
        }
    }
}