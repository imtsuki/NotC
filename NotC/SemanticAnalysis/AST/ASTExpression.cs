using System;
using System.Collections.Generic;
using System.Text;
using NotC.SyntaxAnalysis;
using NotC.LexicalAnalysis;

namespace NotC.AST {
    public class ASTExpression : ASTStatement
    {

    }

    public class Id : ASTExpression
    {

        public Symbol Symbol { get; set; }

        public Id(Symbol symbol)
        {
            Symbol = symbol;
        }

        public override string ToString()
        {
            return $"[Id: {Symbol.Id}]";
        }
    }

    public class IntNumber : ASTExpression
    {

        public Int64 Val { get; set; }

        public IntNumber(Int64 val)
        {
            Val = val;
        }
        public IntNumber(TokenInt token)
        {
            Val = token.Val;
        }

        public override string ToString()
        {
            return $"{Val}";
        }
    }
}
