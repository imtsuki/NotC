using System;
using System.Collections.Generic;
using System.Text;

namespace NotC.SyntaxAnalysis
{
    class SyntaxErrorException : Exception
    {
        public SyntaxErrorException(string message) : base(message)
        {
        }
    }
}
