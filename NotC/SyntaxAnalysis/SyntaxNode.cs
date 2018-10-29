using System.Collections.Generic;

namespace NotC.SyntaxAnalysis {
    public abstract class SyntaxNode {
        public abstract IEnumerable<SyntaxNode> Children();
    }
}