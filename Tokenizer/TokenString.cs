// ***********************************************************************
// Assembly         : C
// Author           : Jason Qiu
// Created          : 03-06-2018
//
// Last Modified By : Jason Qiu
// Last Modified On : 03-15-2018
// ***********************************************************************
// <copyright file="TokenString.cs" company="C">
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
    /// Class TokenString.
    /// </summary>
    /// <seealso cref="C.Tokenizer.Token" />
    public class TokenString : Token
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TokenString"/> class.
        /// </summary>
        /// <param name="val">The value.</param>
        public TokenString(String val)
        {
            this.Val = val;
        }

        /// <summary>
        /// Gets the kind.
        /// </summary>
        /// <value>The kind.</value>
        public override TokenKind Kind { get; } = TokenKind.STRING;
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public String Val { get; }
        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString()
        {
            return $"{this.Kind}: \"{this.Val}\"";
        }
    }
}
