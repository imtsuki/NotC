using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace C.Parser
{
    class Environment
    {
        /// <summary>
        /// Gets or sets the symbol table.
        /// </summary>
        /// <value>The symbol table.</value>
        private Hashtable symbolTable { get; set; } = new Hashtable(new Tokenizer.TokenIdentifier.Comparer());
        /// <summary>
        /// Gets or sets the previous <see cref="Environment" />.
        /// </summary>
        /// <value>The previous <see cref="Environment" />.</value>
        public Environment Previous { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Environment" /> class.
        /// </summary>
        /// <param name="previous">The previous.</param>
        public Environment(Environment previous)
        {
            Previous = previous;
        }

        /// <summary>
        /// Generate a new <see cref="Symbol" /> of the specified identifier.
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
        /// Gets the <see cref="Symbol" /> of the specified identifier.
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

        /// <summary>
        /// Determines whether [contains] [the specified identifier].
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if [contains] [the specified identifier]; otherwise, <c>false</c>.</returns>
        public bool Contains(Tokenizer.TokenIdentifier id)
        {
            return symbolTable.Contains(id);
        }
    }
}
