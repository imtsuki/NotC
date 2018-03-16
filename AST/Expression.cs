// ***********************************************************************
// Assembly         : C
// Author           : Jason Qiu
// Created          : 03-06-2018
//
// Last Modified By : Jason Qiu
// Last Modified On : 03-15-2018
// ***********************************************************************
// <copyright file="ASTExpression.cs" company="C">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using C.Parser;
using C.Tokenizer;

namespace C.AST
{
    /// <summary>
    /// Class ASTExpression.
    /// </summary>
    public class Expression
    {

    }

    public class Id : Expression
    {
        private Symbol symbol;

        public Symbol Symbol { get => symbol; set => symbol = value; }

        public Id(Symbol symbol)
        {
            Symbol = symbol;
        }

        public override string ToString()
        {
            return $"[Id: {symbol.Id}]";
        }
    }

    public class IntNumber : Expression
    {
        public Int64 Val;

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
            return $"[{Val}]";
        }
    }
}
