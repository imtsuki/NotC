using System;
using System.Collections.Generic;
using System.Text;

namespace NotC.AST
{
    /// <summary>
    /// Class Block.
    /// </summary>
    /// <seealso cref="NotC.AST.ASTStatement" />
    public class Block : ASTStatement
    {
        /// <summary>
        /// Gets or sets the statements.
        /// </summary>
        /// <value>The statements.</value>
        public IList<ASTStatement> Statements { get; set; }

        public Block(IList<ASTStatement> statements)
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
