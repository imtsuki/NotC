using System;
using System.Collections.Generic;
using System.Text;

namespace C
{
    public class LexicalScanner
    {
        public LexicalScanner(String source)
        {
            this.Source = source;

        }

        public IEnumerable<Token> Lex()
        {
            return new List<Token>();
        }
        public String Source { get; }
    }
}
