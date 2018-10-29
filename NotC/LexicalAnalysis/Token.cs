using System;
using System.Collections.Generic;
using System.Linq;
using NotC.SyntaxAnalysis;

namespace NotC.LexicalAnalysis
{
    public sealed class Token : SyntaxNode
    {
        public int Position { get; }
        public int Length { get; }
        public TokenKind Kind { get; }

        public object Val;

        public override IEnumerable<SyntaxNode> Children() {
            return Enumerable.Empty<SyntaxNode>();
        }

        private Token(int position, int length) {
            Position = position;
            Length = length;
        }

        public override string ToString() => $"[Token {Kind}: {Val}]";

        private Token(TokenKind kind, object val, int position, int length) {
            Kind = kind;
            Val = val;
            Position = position;
            Length = length;
        }

        public static Token GetToken(TokenKind kind, object val, int position, int length) {
            var token = new Token(kind, val, position, length);
            return token;
        }

        public static Token GetIdentifierToken(string val, int position, int length) {
            var token = new Token(TokenKind.IDENTIFIER, val, position, length);
            return token;
        }

        public static Token GetOperatorToken(string val, int position, int length) {
            var token = new Token(TokenKind.OPERATOR, val, position, length);
            return token;
        }

        public static Token GetKeywordToken(KeywordVal val, int position, int length) {
            var token = new Token(TokenKind.KEYWORD, val, position, length);
            return token;
        }

        public static Token GetIntToken(Int64 val, int position, int length) {
            var token = new Token(TokenKind.INT, val, position, length);
            return token;
        }
        public static Token GetCharToken(char val, int position, int length) {
            var token = new Token(TokenKind.CHAR, val, position, length);
            return token;
        }

        public static Token GetStringToken(string val, int position, int length) {
            var token = new Token(TokenKind.STRING, val, position, length);
            return token;
        }

        public static Token GetEOFToken() {
            var token = new Token(TokenKind.EOF, null, -1, -1);
            return token;
        }

        public static Token GetErrorToken(int position, int length) {
            var token = new Token(TokenKind.EOF, null, position, length);
            return token;
        }
        public static Dictionary<String, OperatorVal> Operators { get; } = new Dictionary<string, OperatorVal>()
        {
            { "[",    OperatorVal.LBRACKET     },
            { "]",    OperatorVal.RBRACKET     },
            { "(",    OperatorVal.LPAREN       },
            { ")",    OperatorVal.RPAREN       },
            { ".",    OperatorVal.PERIOD       },
            { ",",    OperatorVal.COMMA        },
            { "?",    OperatorVal.QUESTION     },
            { ":",    OperatorVal.COLON        },
            { "~",    OperatorVal.TILDE        },
            { "-",    OperatorVal.SUB          },
            { "->",   OperatorVal.RARROW       },
            { "--",   OperatorVal.DEC          },
            { "-=",   OperatorVal.SUBASSIGN    },
            { "+",    OperatorVal.ADD          },
            { "++",   OperatorVal.INC          },
            { "+=",   OperatorVal.ADDASSIGN    },
            { "&",    OperatorVal.BITAND       },
            { "&&",   OperatorVal.AND          },
            { "&=",   OperatorVal.ANDASSIGN    },
            { "*",    OperatorVal.MULT         },
            { "*=",   OperatorVal.MULTASSIGN   },
            { "<",    OperatorVal.LT           },
            { "<=",   OperatorVal.LEQ          },
            { "<<",   OperatorVal.LSHIFT       },
            { "<<=",  OperatorVal.LSHIFTASSIGN },
            { ">",    OperatorVal.GT           },
            { ">=",   OperatorVal.GEQ          },
            { ">>",   OperatorVal.RSHIFT       },
            { ">>=",  OperatorVal.RSHIFTASSIGN },
            { "=",    OperatorVal.ASSIGN       },
            { "==",   OperatorVal.EQ           },
            { "|",    OperatorVal.BITOR        },
            { "||",   OperatorVal.OR           },
            { "|=",   OperatorVal.ORASSIGN     },
            { "!",    OperatorVal.NOT          },
            { "!=",   OperatorVal.NEQ          },
            { "/",    OperatorVal.DIV          },
            { "/=",   OperatorVal.DIVASSIGN    },
            { "%",    OperatorVal.MOD          },
            { "%=",   OperatorVal.MODASSIGN    },
            { "^",    OperatorVal.XOR          },
            { "^=",   OperatorVal.XORASSIGN    },
            { ";",    OperatorVal.SEMICOLON    },
            { "{",    OperatorVal.LCURL        },
            { "}",    OperatorVal.RCURL        }
        };

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
    }
}
