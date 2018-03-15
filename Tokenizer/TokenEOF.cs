// ***********************************************************************
// Assembly         : C
// Author           : Jason Qiu
// Created          : 03-15-2018
//
// Last Modified By : Jason Qiu
// Last Modified On : 03-15-2018
// ***********************************************************************
// <copyright file="TokenEOF.cs" company="C">
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
    /// Class TokenEOF.
    /// </summary>
    /// <seealso cref="C.Tokenizer.Token" />
    class TokenEOF : Token
    {
        /// <summary>
        /// Gets the kind.
        /// </summary>
        /// <value>The kind.</value>
        public override TokenKind Kind { get; } = TokenKind.EOF;
    }
}
