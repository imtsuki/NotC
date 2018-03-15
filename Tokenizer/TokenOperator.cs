// ***********************************************************************
// Assembly         : C
// Author           : Jason Qiu
// Created          : 03-06-2018
//
// Last Modified By : Jason Qiu
// Last Modified On : 03-15-2018
// ***********************************************************************
// <copyright file="TokenOperator.cs" company="C">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;

namespace C.Tokenizer
{
    /// <summary>
    /// Enum OperatorVal
    /// </summary>
    public enum OperatorVal
    {
        /// <summary>
        /// Represents '['. 
        /// </summary>
        LBRACKET,
        /// <summary>
        /// Represents ']'. 
        /// </summary>
        RBRACKET,
        /// <summary>
        /// Represents '('. 
        /// </summary>
        LPAREN,
        /// <summary>
        /// Represents ')'. 
        /// </summary>
        RPAREN,
        /// <summary>
        /// Represents '.'. 
        /// </summary>
        PERIOD,
        /// <summary>
        /// Represents ','. 
        /// </summary>
        COMMA,
        /// <summary>
        /// Represents '?'. 
        /// </summary>
        QUESTION,
        /// <summary>
        /// Represents ':'. 
        /// </summary>
        COLON,
        /// <summary>
        /// Represents '~'. 
        /// </summary>
        TILDE,
        /// <summary>
        /// Represents '-'. 
        /// </summary>
        SUB,
        /// <summary>
        /// Represents '->'.
        /// </summary>
        RARROW,
        /// <summary>
        /// Represents '--'.
        /// </summary>
        DEC,
        /// <summary>
        /// Represents '-='.
        /// </summary>
        SUBASSIGN,
        /// <summary>
        /// Represents '+'. 
        /// </summary>
        ADD,
        /// <summary>
        /// Represents '++'.
        /// </summary>
        INC,
        /// <summary>
        /// Represents '+='.
        /// </summary>
        ADDASSIGN,
        /// <summary>
        /// Represents '&'.
        /// </summary>
        BITAND,
        /// <summary>
        /// Represents '&&'.
        /// </summary>
        AND,
        /// <summary>
        /// Represents '&='.
        /// </summary>
        ANDASSIGN,
        /// <summary>
        /// Represents '*'.
        /// </summary>
        MULT,
        /// <summary>
        /// Represents '*='.
        /// </summary>
        MULTASSIGN,
        /// <summary>
        /// Represents '<'.
        /// </summary>
        LT,
        /// <summary>
        /// Represents '<='.
        /// </summary>
        LEQ,
        /// <summary>
        /// Represents '<<'.
        /// </summary>
        LSHIFT,
        /// <summary>
        /// Represents '<<='.
        /// </summary>
        LSHIFTASSIGN,
        /// <summary>
        /// Represents '>'.
        /// </summary>
        GT,
        /// <summary>
        /// Represents '>='.
        /// </summary>
        GEQ,
        /// <summary>
        /// Represents '>>'.
        /// </summary>
        RSHIFT,
        /// <summary>
        /// Represents '>>='.
        /// </summary>
        RSHIFTASSIGN,
        /// <summary>
        /// Represents '='.
        /// </summary>
        ASSIGN,
        /// <summary>
        /// Represents '=='.
        /// </summary>
        EQ,
        /// <summary>
        /// Represents '|'.
        /// </summary>
        BITOR,
        /// <summary>
        /// Represents '||'.
        /// </summary>
        OR,
        /// <summary>
        /// Represents '|='.
        /// </summary>
        ORASSIGN,
        /// <summary>
        /// Represents '!'.
        /// </summary>
        NOT,
        /// <summary>
        /// Represents '!='.
        /// </summary>
        NEQ,
        /// <summary>
        /// Represents '/'.
        /// </summary>
        DIV,
        /// <summary>
        /// Represents '/='.
        /// </summary>
        DIVASSIGN,
        /// <summary>
        /// Represents '%'.
        /// </summary>
        MOD,
        /// <summary>
        /// Represents '%='.
        /// </summary>
        MODASSIGN,
        /// <summary>
        /// Represents '^'.
        /// </summary>
        XOR,
        /// <summary>
        /// Represents '^='.
        /// </summary>
        XORASSIGN,
        /// <summary>
        /// Represents ';'.
        /// </summary>
        SEMICOLON,
        /// <summary>
        /// Represents '{'. 
        /// </summary>
        LCURL,
        /// <summary>
        /// Represents '}'. 
        /// </summary>
        RCURL
    }
    /// <summary>
    /// Class TokenOperator.
    /// </summary>
    /// <seealso cref="C.Tokenizer.Token" />
    public class TokenOperator : Token
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TokenOperator"/> class.
        /// </summary>
        /// <param name="val">The value.</param>
        public TokenOperator(OperatorVal val)
        {
            this.Val = val;
        }
        /// <summary>
        /// Gets the kind.
        /// </summary>
        /// <value>The kind.</value>
        public override TokenKind Kind { get; } = TokenKind.OPERATOR;
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public OperatorVal Val { get; }
        /// <summary>
        /// Gets the operators.
        /// </summary>
        /// <value>The operators.</value>
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
        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString()
        {
            return $"{this.Kind}: {this.Val}: {Operators.First(pair => pair.Value == this.Val).Key}";
        }
    }
}