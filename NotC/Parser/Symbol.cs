using System;
using System.Collections.Generic;
using System.Text;

namespace NotC.Parser
{
    public class Symbol
    {
        private static int count { get; set; } = -1;
        private static int NextId()
        {
            count++;
            return count;
        }

        public int Id { get; }
        public Symbol()
        {
            Id = NextId();
        }
    }
}
