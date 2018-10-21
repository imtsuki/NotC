// ***********************************************************************
// Assembly         : C
// Author           : Jason Qiu
// Created          : 03-17-2018
//
// Last Modified By : Jason Qiu
// Last Modified On : 03-21-2018
// ***********************************************************************
// <copyright file="Block.cs" company="C">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace NotC.AST
{
    /// <summary>
    /// Class Block.
    /// </summary>
    /// <seealso cref="NotC.AST.Statement" />
    public class Block : Statement
    {
        /// <summary>
        /// Gets or sets the statements.
        /// </summary>
        /// <value>The statements.</value>
        public IList<Statement> Statements { get; set; }

        public Block(IList<Statement> statements)
        {
            Statements = statements;
        }

        public override string ToString()
        {
            string result = "{\n";
            foreach (var statement in Statements)
            {
                result += statement.ToString();
            }
            result += "\n}\n";
            return result;
        }
    }
}
