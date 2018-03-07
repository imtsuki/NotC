// ***********************************************************************
// Assembly         : C
// Author           : super
// Created          : 03-06-2018
//
// Last Modified By : super
// Last Modified On : 03-06-2018
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
        /// The lbracket
        /// </summary>
        LBRACKET,
        /// <summary>
        /// The rbracket
        /// </summary>
        RBRACKET,
        /// <summary>
        /// The lparen
        /// </summary>
        LPAREN,
        /// <summary>
        /// The rparen
        /// </summary>
        RPAREN,
        /// <summary>
        /// The period
        /// </summary>
        PERIOD,
        /// <summary>
        /// The comma
        /// </summary>
        COMMA,
        /// <summary>
        /// The question
        /// </summary>
        QUESTION,
        /// <summary>
        /// The colon
        /// </summary>
        COLON,
        /// <summary>
        /// The tilde
        /// </summary>
        TILDE,
        /// <summary>
        /// The sub
        /// </summary>
        SUB,
        /// <summary>
        /// The rarrow
        /// </summary>
        RARROW,
        /// <summary>
        /// The decimal
        /// </summary>
        DEC,
        /// <summary>
        /// The subassign
        /// </summary>
        SUBASSIGN,
        /// <summary>
        /// The add
        /// </summary>
        ADD,
        /// <summary>
        /// The inc
        /// </summary>
        INC,
        /// <summary>
        /// The addassign
        /// </summary>
        ADDASSIGN,
        /// <summary>
        /// The bitand
        /// </summary>
        BITAND,
        /// <summary>
        /// The and
        /// </summary>
        AND,
        /// <summary>
        /// The andassign
        /// </summary>
        ANDASSIGN,
        /// <summary>
        /// The mult
        /// </summary>
        MULT,
        /// <summary>
        /// The multassign
        /// </summary>
        MULTASSIGN,
        /// <summary>
        /// The lt
        /// </summary>
        LT,
        /// <summary>
        /// The leq
        /// </summary>
        LEQ,
        /// <summary>
        /// The lshift
        /// </summary>
        LSHIFT,
        /// <summary>
        /// The lshiftassign
        /// </summary>
        LSHIFTASSIGN,
        /// <summary>
        /// The gt
        /// </summary>
        GT,
        /// <summary>
        /// The geq
        /// </summary>
        GEQ,
        /// <summary>
        /// The rshift
        /// </summary>
        RSHIFT,
        /// <summary>
        /// The rshiftassign
        /// </summary>
        RSHIFTASSIGN,
        /// <summary>
        /// The assign
        /// </summary>
        ASSIGN,
        /// <summary>
        /// The eq
        /// </summary>
        EQ,
        /// <summary>
        /// The bitor
        /// </summary>
        BITOR,
        /// <summary>
        /// The or
        /// </summary>
        OR,
        /// <summary>
        /// The orassign
        /// </summary>
        ORASSIGN,
        /// <summary>
        /// The not
        /// </summary>
        NOT,
        /// <summary>
        /// The neq
        /// </summary>
        NEQ,
        /// <summary>
        /// The div
        /// </summary>
        DIV,
        /// <summary>
        /// The divassign
        /// </summary>
        DIVASSIGN,
        /// <summary>
        /// The mod
        /// </summary>
        MOD,
        /// <summary>
        /// The modassign
        /// </summary>
        MODASSIGN,
        /// <summary>
        /// The xor
        /// </summary>
        XOR,
        /// <summary>
        /// The xorassign
        /// </summary>
        XORASSIGN,
        /// <summary>
        /// The semicolon
        /// </summary>
        SEMICOLON,
        /// <summary>
        /// The lcurl
        /// </summary>
        LCURL,
        /// <summary>
        /// The rcurl
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