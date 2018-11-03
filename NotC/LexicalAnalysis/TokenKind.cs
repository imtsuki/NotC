namespace NotC.LexicalAnalysis {
    public enum TokenKind {
        NONE,
        FLOAT,
        INT,
        CHAR,
        STRING,
        IDENTIFIER,
        KEYWORD,
        OPERATOR,
        EOF,
        ERROR
    }
}
