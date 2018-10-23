using System;
using System.Collections.Generic;

namespace NotC.LexicalAnalysis
{
    public sealed class TokenKeyword : Token
    {
        public TokenKeyword(KeywordVal val) => this.Val = val;

        public override TokenKind Kind { get; } = TokenKind.KEYWORD;

        public KeywordVal Val { get; }

        public static Dictionary<String, KeywordVal> Keywords { get; } = new Dictionary<string, KeywordVal>()
        {
            { "auto",        KeywordVal.AUTO      },
            { "double",      KeywordVal.DOUBLE    },
            { "int",         KeywordVal.INT       },
            { "struct",      KeywordVal.STRUCT    },
            { "break",       KeywordVal.BREAK     },
            { "else",        KeywordVal.ELSE      },
            { "long",        KeywordVal.LONG      },
            { "switch",      KeywordVal.SWITCH    },
            { "case",        KeywordVal.CASE      },
            { "enum",        KeywordVal.ENUM      },
            { "register",    KeywordVal.REGISTER  },
            { "typedef",     KeywordVal.TYPEDEF   },
            { "char",        KeywordVal.CHAR      },
            { "extern",      KeywordVal.EXTERN    },
            { "return",      KeywordVal.RETURN    },
            { "union",       KeywordVal.UNION     },
            { "const",       KeywordVal.CONST     },
            { "float",       KeywordVal.FLOAT     },
            { "short",       KeywordVal.SHORT     },
            { "unsigned",    KeywordVal.UNSIGNED  },
            { "continue",    KeywordVal.CONTINUE  },
            { "for",         KeywordVal.FOR       },
            { "signed",      KeywordVal.SIGNED    },
            { "void",        KeywordVal.VOID      },
            { "default",     KeywordVal.DEFAULT   },
            { "goto",        KeywordVal.GOTO      },
            { "sizeof",      KeywordVal.SIZEOF    },
            { "volatile",    KeywordVal.VOLATILE  },
            { "do",          KeywordVal.DO        },
            { "if",          KeywordVal.IF        },
            { "static",      KeywordVal.STATIC    },
            { "while",       KeywordVal.WHILE     }
        };

        public override String ToString() => $"{this.Kind}: {this.Val}";
    }
}