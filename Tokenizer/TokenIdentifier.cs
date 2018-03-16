// ***********************************************************************
// Assembly         : C
// Author           : Jason Qiu
// Created          : 03-06-2018
//
// Last Modified By : Jason Qiu
// Last Modified On : 03-15-2018
// ***********************************************************************
// <copyright file="TokenIdentifier.cs" company="C">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;

namespace C.Tokenizer
{
    

    /// <summary>
    /// Class TokenIdentifier.
    /// </summary>
    /// <seealso cref="C.Tokenizer.Token" />
    public class TokenIdentifier : Token
    {
        public class Comparer : IEqualityComparer
        {
            public new bool Equals(object x, object y)
            {
                return ((TokenIdentifier)x).Val.Equals(((TokenIdentifier)y).Val);
            }

            public int GetHashCode(object obj)
            {
                return ((TokenIdentifier)obj).Val.GetHashCode();
            }
        }

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