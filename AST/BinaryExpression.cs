// ***********************************************************************
// Assembly         : C
// Author           : Jason Qiu
// Created          : 03-06-2018
//
// Last Modified By : Jason Qiu
// Last Modified On : 03-16-2018
// ***********************************************************************
// <copyright file="ASTBinaryExpression.cs" company="C">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using C.Tokenizer;

namespace C.AST
{
    /// <summary>
    /// Represents a binary expression node in an AST. 
    /// </summary>
    /// <seealso cref="C.AST.Expression" />
    public class BinaryExpression : Expression
    {
        /// <summary>
        /// The right element of the expression.
        /// </summary>
        private Expression right;
        /// <summary>
        /// The left element of the expression.
        /// </summary>
        private Expression left;


        /// <summary>
        /// Gets or sets the left element of the expression.
        /// </summary>
        /// <value>The LHS.</value>
        public Expression Left { get => left; set => left = value; }
        /// <summary>
        /// Gets or sets the right element of the expression.
        /// </summary>
        /// <value>The RHS.</value>
        public Expression Right { get => right; set => right = value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryExpression"/> class.
        /// </summary>
        /// <param name="left">The left element.</param>
        /// <param name="right">The right element.</param>
        public BinaryExpression(Expression left, Expression right)
        {
            Left = left;
            Right = right;
        }
    }

    /// <summary>
    /// The specific <see cref="BinaryExpression"/> class of '+'.
    /// </summary>
    /// <seealso cref="C.AST.BinaryExpression" />
    public class Add : BinaryExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Add"/> class.
        /// </summary>
        /// <param name="left">The left element.</param>
        /// <param name="right">The right element.</param>
        public Add(Expression left, Expression right) : base(left, right)
        {

        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return $"({Left.ToString()} + {Right.ToString()})";
        }
    }

    /// <summary>
    /// The specific <see cref="BinaryExpression"/> class of '-'.
    /// </summary>
    /// <seealso cref="C.AST.BinaryExpression" />
    public class Sub : BinaryExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Sub"/> class.
        /// </summary>
        /// <param name="left">The left element.</param>
        /// <param name="right">The right element.</param>
        public Sub(Expression left, Expression right) : base(left, right)
        {

        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return $"({Left.ToString()} - {Right.ToString()})";
        }
    }
    /// <summary>
    /// The specific <see cref="BinaryExpression"/> class of '*'.
    /// </summary>
    /// <seealso cref="C.AST.BinaryExpression" />
    public class Mult : BinaryExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Mult"/> class.
        /// </summary>
        /// <param name="left">The left element.</param>
        /// <param name="right">The right element.</param>
        public Mult(Expression left, Expression right) : base(left, right)
        {

        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return $"({Left.ToString()} * {Right.ToString()})";
        }
    }

    /// <summary>
    /// The specific <see cref="BinaryExpression"/> class of '/'.
    /// </summary>
    /// <seealso cref="C.AST.BinaryExpression" />
    public class Div : BinaryExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Div"/> class.
        /// </summary>
        /// <param name="left">The left element.</param>
        /// <param name="right">The right element.</param>
        public Div(Expression left, Expression right) : base(left, right)
        {

        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return $"({Left.ToString()} / {Right.ToString()})";
        }
    }
}

