// ***********************************************************************
// Assembly         : C
// Author           : Jason Qiu
// Created          : 03-15-2018
//
// Last Modified By : Jason Qiu
// Last Modified On : 03-16-2018
// ***********************************************************************
// <copyright file="OperatorVal.cs" company="C">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

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
}