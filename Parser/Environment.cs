// ***********************************************************************
// Assembly         : C
// Author           : Jason Qiu
// Created          : 03-16-2018
//
// Last Modified By : Jason Qiu
// Last Modified On : 03-16-2018
// ***********************************************************************
// <copyright file="Environment.cs" company="C">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace C.Parser
{
    /// <summary>
    /// Class Environment.
    /// </summary>
    class Environment
    {
        /// <summary>
        /// The symbol table
        /// </summary>
        private Hashtable symbolTable = new Hashtable(new Tokenizer.TokenIdentifier.Comparer());
        /// <summary>
        /// Gets or sets the previous.
        /// </summary>
        /// <value>The previous.</value>
        protected Environment Previous
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Environment" /> class.
        /// </summary>
        /// <param name="previous">The previous.</param>
        public Environment(Environment previous)
        {
            Previous = previous;
        }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Put(Tokenizer.TokenIdentifier id)
        {
            if (!this.Contains(id))
            {
                symbolTable.Add(id, new Symbol());
            }
            else
            {
                // throw new SyntaxErrorException($"Identifier [{id.Val}] redefined. ");
            }
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Symbol.</returns>
        public Symbol Get(Tokenizer.TokenIdentifier id)
        {
            for (Environment env = this; env != null; env = env.Previous)
            {
                if (env.symbolTable.Contains(id))
                {
                    return (Symbol)env.symbolTable[id];
                }
            }
            return null;
        }

        public bool Contains(Tokenizer.TokenIdentifier id)
        {
            return symbolTable.Contains(id);
        }
    }
}
