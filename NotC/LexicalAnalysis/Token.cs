using System;
using System.Collections.Generic;
using System.Text;

namespace NotC.LexicalAnalysis
{
    public enum TokenKind
    {
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

    public abstract class Token
    {
        public override String ToString()
        {
            return Kind.ToString();
        }
        int position;
        public abstract TokenKind Kind { get; }
    }
}
