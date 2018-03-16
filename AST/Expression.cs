// ***********************************************************************
// Assembly         : C
// Author           : Jason Qiu
// Created          : 03-06-2018
//
// Last Modified By : Jason Qiu
// Last Modified On : 03-16-2018
// ***********************************************************************
// <copyright file="ASTExpression.cs" company="C">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using C.Parser;
using C.Tokenizer;

namespace C.AST
{
    /// <summary>
    /// Represents an expression node in an AST.
    /// </summary>
    /// <seealso cref="C.AST.ASTBase" />
    public class Expression : ASTBase
    {

    }

    /// <summary>
    /// Represents an identifier node in an AST.
    /// </summary>
    /// <seealso cref="C.AST.Expression" />
    public class Id : Expression
    {
        private Symbol symbol;

        /// <summary>
        /// Gets or sets the symbol.
        /// </summary>
        /// <value>The symbol.</value>
        public Symbol Symbol { get => symbol; set => symbol = value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Id"/> class.
        /// </summary>
        /// <param name="symbol">The symbol.</param>
        public Id(Symbol symbol)
        {
            Symbol = symbol;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return $"[Id: {symbol.Id}]";
        }
    }

    /// <summary>
    /// Represents an integer literal node in an AST.
    /// </summary>
    /// <seealso cref="C.AST.Expression" />
    public class IntNumber : Expression
    {
        /// <summary>
        /// The value
        /// </summary>
        public Int64 Val;

        /// <summary>
        /// Initializes a new instance of the <see cref="IntNumber"/> class.
        /// </summary>
        /// <param name="val">The value.</param>
        public IntNumber(Int64 val)
        {
            Val = val;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="IntNumber"/> class.
        /// </summary>
        /// <param name="token">The token.</param>
        public IntNumber(TokenInt token)
        {
            Val = token.Val;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return $"{Val}";
        }
    }
}
