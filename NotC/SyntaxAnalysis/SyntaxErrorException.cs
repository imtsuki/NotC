using System;
using System.Collections.Generic;
using System.Text;

namespace NotC.Parser
{
    class SyntaxErrorException : Exception
    {
        public SyntaxErrorException(string message) : base(message)
        {
        }
    }
}
