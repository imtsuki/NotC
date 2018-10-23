using System;
using System.Collections;

namespace NotC.LexicalAnalysis
{
    public sealed class TokenIdentifier : Token
    {
        public class Comparer : IEqualityComparer
        {
            public new bool Equals(object x, object y)
            {
                return ((TokenIdentifier)x).Val.Equals(((TokenIdentifier)y).Val);
            }

            public int GetHashCode(object obj)
            {
                return ((TokenIdentifier)obj).Val.GetHashCode();
            }
        }

        public TokenIdentifier(String val)
        {
            this.Val = val;
        }

        public override TokenKind Kind { get; } = TokenKind.IDENTIFIER;

        public String Val { get; }

        public override string ToString()
        {
            return $"{this.Kind}: [{this.Val}]";
        }
    }
}