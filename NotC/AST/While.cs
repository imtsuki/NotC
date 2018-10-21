// ***********************************************************************
// Assembly         : C
// Author           : Jason Qiu
// Created          : 03-21-2018
//
// Last Modified By : Jason Qiu
// Last Modified On : 03-21-2018
// ***********************************************************************
// <copyright file="While.cs" company="C">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace NotC.AST
{
    class While : Statement
    {
        /// <summary>
        /// Gets or sets the condition.
        /// </summary>
        /// <value>The condition.</value>
        public Expression Condition { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>The body.</value>
        public Statement Body { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="While"/> class with structure like:
        /// while (Condition)
        ///     Body
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="body">The body.</param>
        public While(Expression condition, Statement body)
        {
            Condition = condition;
            Body = body;
        }

        public override string ToString()
        {
            return $"while ({Condition.ToString()}) {Body.ToString()}";
        }
    }
}
