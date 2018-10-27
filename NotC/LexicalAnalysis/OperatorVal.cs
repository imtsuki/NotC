namespace NotC.LexicalAnalysis
{
    public enum OperatorVal
    {
        // Represents '['. 
        LBRACKET,
        // Represents ']'. 
        RBRACKET,
        // Represents '('. 
        LPAREN,
        // Represents ')'. 
        RPAREN,
        // Represents '.'. 
        PERIOD,
        // Represents ','. 
        COMMA,
        // Represents '?'. 
        QUESTION,
        // Represents ':'. 
        COLON,
        // Represents '~'. 
        TILDE,
        // Represents '-'. 
        SUB,
        // Represents '->'.
        RARROW,
        // Represents '--'.
        DEC,
        // Represents '-='.
        SUBASSIGN,
        // Represents '+'. 
        ADD,
        // Represents '++'.
        INC,
        // Represents '+='.
        ADDASSIGN,
        // Represents '&'.
        BITAND,
        // Represents '&&'.
        AND,
        // Represents '&='.
        ANDASSIGN,
        // Represents '*'.
        MULT,
        // Represents '*='.
        MULTASSIGN,
        // Represents '<'.
        LT,
        // Represents '<='.
        LEQ,
        // Represents '<<'.
        LSHIFT,
        // Represents '<<='.
        LSHIFTASSIGN,
        // Represents '>'.
        GT,
        // Represents '>='.
        GEQ,
        // Represents '>>'.
        RSHIFT,
        // Represents '>>='.
        RSHIFTASSIGN,
        // Represents '='.
        ASSIGN,
        // Represents '=='.
        EQ,
        // Represents '|'.
        BITOR,
        // Represents '||'.
        OR,
        // Represents '|='.
        ORASSIGN,
        // Represents '!'.
        NOT,
        // Represents '!='.
        NEQ,
        // Represents '/'.
        DIV,
        // Represents '/='.
        DIVASSIGN,
        // Represents '%'.
        MOD,
        // Represents '%='.
        MODASSIGN,
        // Represents '^'.
        XOR,
        // Represents '^='.
        XORASSIGN,
        // Represents ';'.
        SEMICOLON,
        // Represents '{'. 
        LCURL,
        // Represents '}'. 
        RCURL
    }
}