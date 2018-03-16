// ***********************************************************************
// Assembly         : C
// Author           : Jason Qiu
// Created          : 03-06-2018
//
// Last Modified By : Jason Qiu
// Last Modified On : 03-15-2018
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
    /// Class ASTBinaryExpression.
    /// </summary>
    /// <seealso cref="C.AST.Expression" />
    public class BinaryExpression : Expression
    {
        /// <summary>
        /// The right Expr
        /// </summary>
        private Expression right;
        /// <summary>
        /// The left Expr
        /// </summary>
        private Expression left;


        /// <summary>
        /// Gets or sets the LHS.
        /// </summary>
        /// <value>The LHS.</value>
        public Expression Left { get => left; set => left = value; }
        /// <summary>
        /// Gets or sets the RHS.
        /// </summary>
        /// <value>The RHS.</value>
        public Expression Right { get => right; set => right = value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryExpression"/> class.
        /// </summary>
        /// <param name="left">The l hs.</param>
        /// <param name="right">The r hs.</param>
        public BinaryExpression(Expression left, Expression right)
        {
            Left = left;
            Right = right;
        }
    }

    public class Add : BinaryExpression
    {
        public Add(Expression left, Expression right) : base(left, right)
        {

        }

        public override string ToString()
        {
            return $"{Left.ToString()} {Right.ToString()} +";
        }
    }

    public class Sub : BinaryExpression
    {
        public Sub(Expression left, Expression right) : base(left, right)
        {

        }

        public override string ToString()
        {
            return $"{Left.ToString()} {Right.ToString()} -";
        }
    }
    public class Mult : BinaryExpression
    {
        public Mult(Expression left, Expression right) : base(left, right)
        {

        }

        public override string ToString()
        {
            return $"{Left.ToString()} {Right.ToString()} *";
        }
    }

    public class Div : BinaryExpression
    {
        public Div(Expression left, Expression right) : base(left, right)
        {

        }

        public override string ToString()
        {
            return $"{Left.ToString()} {Right.ToString()} /";
        }
    }
}

