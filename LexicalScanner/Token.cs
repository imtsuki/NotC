using System;
using System.Collections.Generic;
using System.Text;

namespace C
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
        OPERATOR
    }

    public abstract class Token
    {
        public override String ToString()
        {
            return Kind.ToString();
        }
        public abstract TokenKind Kind { get; }
    }
}
