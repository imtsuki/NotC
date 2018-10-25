namespace NotC.SyntaxAnalysis {
    internal class Truth {
        public static int GetOperatorPrecedence(string @operator) {
            switch (@operator) {
                case "*":
                case "/":
                    return 1;
                case "+":
                case "-":
                default:
                    return 0;
            }
        }
    }
}