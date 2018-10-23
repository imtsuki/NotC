using System;
using System.Collections.Generic;
using System.Text;

namespace NotC.AST
{
    /// <summary>
    /// Class If.
    /// </summary>
    /// <seealso cref="NotC.AST.ASTStatement" />
    public class If : ASTStatement
    {
        /// <summary>
        /// Gets or sets the condition.
        /// </summary>
        /// <value>The condition.</value>
        public ASTExpression Condition { get; set; }
        /// <summary>
        /// Gets or sets the true body.
        /// </summary>
        /// <value>The true body.</value>
        public ASTStatement TrueBody { get; set; }
        /// <summary>
        /// Gets or sets the false body.
        /// </summary>
        /// <value>The false body.</value>
        public ASTStatement FalseBody { get; set; }

        /// <summary>
        /// Gets or sets the (true) body.
        /// </summary>
        /// <value>The (true) body.</value>
        public ASTStatement Body => TrueBody;

        /// <summary>
        /// Initializes a new instance of the <see cref="If"/> class with structure like:
        /// if (Condition)
        ///     Body
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="body">The body.</param>
        public If(ASTExpression condition, ASTStatement body)
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
        public If(ASTExpression condition, ASTStatement trueBody, ASTStatement falseBody)
        {
            Condition = condition;
            TrueBody = trueBody;
            FalseBody = falseBody;

        }

        public override string ToString()
        {
            return $"if ({Condition.ToString()}) {TrueBody.ToString()}";
        }
    }
}
