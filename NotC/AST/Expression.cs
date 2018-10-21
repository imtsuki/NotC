// ***********************************************************************
// Assembly         : C
// Author           : Jason Qiu
// Created          : 03-06-2018
//
// Last Modified By : Jason Qiu
// Last Modified On : 03-19-2018
// ***********************************************************************
// <copyright file="ASTExpression.cs" company="C">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using NotC.Parser;
using NotC.Tokenizer;

namespace NotC.AST
{
    /// <summary>
    /// Represents an expression node in an AST.
    /// </summary>
    /// <seealso cref="NotC.AST.Statement" />
    public class Expression : Statement
    {

    }

    /// <summary>
    /// Represents an identifier node in an AST.
    /// </summary>
    /// <seealso cref="NotC.AST.Expression" />
    public class Id : Expression
    {
        /// <summary>
        /// Gets or sets the symbol.
        /// </summary>
        /// <value>The symbol.</value>
        public Symbol Symbol { get; set; }

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
            return $"[Id: {Symbol.Id}]";
        }
    }

    /// <summary>
    /// Represents an integer literal node in an AST.
    /// </summary>
    /// <seealso cref="NotC.AST.Expression" />
    public class IntNumber : Expression
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public Int64 Val { get; set; }

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
