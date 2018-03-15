// ***********************************************************************
// Assembly         : C
// Author           : Jason Qiu
// Created          : 03-06-2018
//
// Last Modified By : Jason Qiu
// Last Modified On : 03-15-2018
// ***********************************************************************
// <copyright file="TokenKeyword.cs" company="C">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;

namespace C.Tokenizer
{
    /// <summary>
    /// Enum KeywordVal
    /// </summary>
    public enum KeywordVal
    {
        /// <summary>
        /// The automatic
        /// </summary>
        AUTO,
        /// <summary>
        /// The double
        /// </summary>
        DOUBLE,
        /// <summary>
        /// The int
        /// </summary>
        INT,
        /// <summary>
        /// The structure
        /// </summary>
        STRUCT,
        /// <summary>
        /// The break
        /// </summary>
        BREAK,
        /// <summary>
        /// The else
        /// </summary>
        ELSE,
        /// <summary>
        /// The long
        /// </summary>
        LONG,
        /// <summary>
        /// The switch
        /// </summary>
        SWITCH,
        /// <summary>
        /// The case
        /// </summary>
        CASE,
        /// <summary>
        /// The enum
        /// </summary>
        ENUM,
        /// <summary>
        /// The register
        /// </summary>
        REGISTER,
        /// <summary>
        /// The typedef
        /// </summary>
        TYPEDEF,
        /// <summary>
        /// The character
        /// </summary>
        CHAR,
        /// <summary>
        /// The extern
        /// </summary>
        EXTERN,
        /// <summary>
        /// The return
        /// </summary>
        RETURN,
        /// <summary>
        /// The union
        /// </summary>
        UNION,
        /// <summary>
        /// The constant
        /// </summary>
        CONST,
        /// <summary>
        /// The float
        /// </summary>
        FLOAT,
        /// <summary>
        /// The short
        /// </summary>
        SHORT,
        /// <summary>
        /// The unsigned
        /// </summary>
        UNSIGNED,
        /// <summary>
        /// The continue
        /// </summary>
        CONTINUE,
        /// <summary>
        /// For
        /// </summary>
        FOR,
        /// <summary>
        /// The signed
        /// </summary>
        SIGNED,
        /// <summary>
        /// The void
        /// </summary>
        VOID,
        /// <summary>
        /// The default
        /// </summary>
        DEFAULT,
        /// <summary>
        /// The goto
        /// </summary>
        GOTO,
        /// <summary>
        /// The sizeof
        /// </summary>
        SIZEOF,
        /// <summary>
        /// The volatile
        /// </summary>
        VOLATILE,
        /// <summary>
        /// The do
        /// </summary>
        DO,
        /// <summary>
        /// If
        /// </summary>
        IF,
        /// <summary>
        /// The static
        /// </summary>
        STATIC,
        /// <summary>
        /// The while
        /// </summary>
        WHILE
    }
    /// <summary>
    /// Class TokenKeyword.
    /// </summary>
    /// <seealso cref="C.Tokenizer.Token" />
    public class TokenKeyword : Token
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TokenKeyword"/> class.
        /// </summary>
        /// <param name="val">The value.</param>
        public TokenKeyword(KeywordVal val) => this.Val = val;
        /// <summary>
        /// Gets the kind.
        /// </summary>
        /// <value>The kind.</value>
        public override TokenKind Kind { get; } = TokenKind.KEYWORD;
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public KeywordVal Val { get; }
        /// <summary>
        /// Gets the keywords.
        /// </summary>
        /// <value>The keywords.</value>
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
        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString() => $"{this.Kind}: {this.Val}";
    }
}