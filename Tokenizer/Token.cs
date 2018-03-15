// ***********************************************************************
// Assembly         : C
// Author           : super
// Created          : 03-06-2018
//
// Last Modified By : super
// Last Modified On : 03-06-2018
// ***********************************************************************
// <copyright file="Token.cs" company="C">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace C.Tokenizer
{
    /// <summary>
    /// Enum TokenKind
    /// </summary>
    public enum TokenKind
    {
        /// <summary>
        /// The none
        /// </summary>
        NONE,
        /// <summary>
        /// The float
        /// </summary>
        FLOAT,
        /// <summary>
        /// The int
        /// </summary>
        INT,
        /// <summary>
        /// The character
        /// </summary>
        CHAR,
        /// <summary>
        /// The string
        /// </summary>
        STRING,
        /// <summary>
        /// The identifier
        /// </summary>
        IDENTIFIER,
        /// <summary>
        /// The keyword
        /// </summary>
        KEYWORD,
        /// <summary>
        /// The operator
        /// </summary>
        OPERATOR,
        /// <summary>
        /// The end
        /// </summary>
        EOF
    }

    /// <summary>
    /// Class Token.
    /// </summary>
    public abstract class Token
    {
        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString()
        {
            return Kind.ToString();
        }
        /// <summary>
        /// Gets the kind.
        /// </summary>
        /// <value>The kind.</value>
        public abstract TokenKind Kind { get; }
    }
}
