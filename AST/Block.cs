// ***********************************************************************
// Assembly         : C
// Author           : Jason Qiu
// Created          : 03-17-2018
//
// Last Modified By : Jason Qiu
// Last Modified On : 03-18-2018
// ***********************************************************************
// <copyright file="Block.cs" company="C">
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
    /// Class Block.
    /// </summary>
    /// <seealso cref="C.AST.Statement" />
    public class Block : Statement
    {
        /// <summary>
        /// Gets or sets the statements.
        /// </summary>
        /// <value>The statements.</value>
        public List<Statement> Statements { get; set; }
    }
}
