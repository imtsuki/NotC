// ***********************************************************************
// Assembly         : C
// Author           : Jason Qiu
// Created          : 03-17-2018
//
// Last Modified By : Jason Qiu
// Last Modified On : 03-18-2018
// ***********************************************************************
// <copyright file="If.cs" company="C">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace C.AST
{
    /// <summary>
    /// Class If.
    /// </summary>
    /// <seealso cref="C.AST.Statement" />
    public class If : Statement
    {
        /// <summary>
        /// Gets or sets the condition.
        /// </summary>
        /// <value>The condition.</value>
        public Expression Condition { get; set; }
        /// <summary>
        /// Gets or sets the true body.
        /// </summary>
        /// <value>The true body.</value>
        public Statement TrueBody { get; set; }
        /// <summary>
        /// Gets or sets the false body.
        /// </summary>
        /// <value>The false body.</value>
        public Statement FalseBody { get; set; }

        /// <summary>
        /// Gets or sets the (true) body.
        /// </summary>
        /// <value>The (true) body.</value>
        public Statement Body => TrueBody;

        /// <summary>
        /// Initializes a new instance of the <see cref="If"/> class with structure like:
        /// if (Condition)
        ///     Body
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="body">The body.</param>
        public If(Expression condition, Statement body)
        {
            Condition = condition;
            TrueBody = body;
            FalseBody = null;

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="If"/> class with structure like:
        /// if (Condition)
        ///     TrueBody
        /// else
        ///     FalseBody
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="trueBody">The true body.</param>
        /// <param name="falseBody">The false body.</param>
        public If(Expression condition, Statement trueBody, Statement falseBody)
        {
            Condition = condition;
            TrueBody = trueBody;
            FalseBody = falseBody;

        }

    }
}
