// ***********************************************************************
// Assembly         : C
// Author           : super
// Created          : 03-06-2018
//
// Last Modified By : super
// Last Modified On : 03-06-2018
// ***********************************************************************
// <copyright file="TokenIdentifier.cs" company="C">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace C.Tokenizer
{
    /// <summary>
    /// Class TokenIdentifier.
    /// </summary>
    /// <seealso cref="C.Tokenizer.Token" />
    public class TokenIdentifier : Token
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TokenIdentifier"/> class.
        /// </summary>
        /// <param name="val">The value.</param>
        public TokenIdentifier(String val)
        {
            this.Val = val;
        }
        /// <summary>
        /// Gets the kind.
        /// </summary>
        /// <value>The kind.</value>
        public override TokenKind Kind { get; } = TokenKind.IDENTIFIER;
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public String Val { get; }
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return $"{this.Kind}: [{this.Val}]";
        }
    }
}