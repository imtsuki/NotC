// ***********************************************************************
// Assembly         : C
// Author           : super
// Created          : 03-06-2018
//
// Last Modified By : super
// Last Modified On : 03-06-2018
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
    /// <seealso cref="C.AST.ASTExpression" />
    public class ASTBinaryExpression : ASTExpression
    {
        /// <summary>
        /// The operator
        /// </summary>
        private Tokenizer.TokenOperator @operator;
        /// <summary>
        /// The r hs
        /// </summary>
        private ASTExpression rHS;
        /// <summary>
        /// The l hs
        /// </summary>
        private ASTExpression lHS;

        /// <summary>
        /// Gets or sets the operator.
        /// </summary>
        /// <value>The operator.</value>
        public TokenOperator Operator { get => @operator; set => @operator = value; }
        /// <summary>
        /// Gets or sets the LHS.
        /// </summary>
        /// <value>The LHS.</value>
        public ASTExpression LHS { get => lHS; set => lHS = value; }
        /// <summary>
        /// Gets or sets the RHS.
        /// </summary>
        /// <value>The RHS.</value>
        public ASTExpression RHS { get => rHS; set => rHS = value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASTBinaryExpression"/> class.
        /// </summary>
        /// <param name="operator">The operator.</param>
        /// <param name="lHS">The l hs.</param>
        /// <param name="rHS">The r hs.</param>
        public ASTBinaryExpression(TokenOperator @operator, ASTExpression lHS, ASTExpression rHS)
        {
            Operator = @operator;
            LHS = lHS;
            RHS = rHS;
        }
    }
}
