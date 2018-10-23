using System;
using System.Collections.Generic;
using System.Text;

namespace NotC.AST
{
    class While : ASTStatement
    {
        /// <summary>
        /// Gets or sets the condition.
        /// </summary>
        /// <value>The condition.</value>
        public ASTExpression Condition { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>The body.</value>
        public ASTStatement Body { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="While"/> class with structure like:
        /// while (Condition)
        ///     Body
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="body">The body.</param>
        public While(ASTExpression condition, ASTStatement body)
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
