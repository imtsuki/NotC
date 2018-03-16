// ***********************************************************************
// Assembly         : C
// Author           : Jason Qiu
// Created          : 03-06-2018
//
// Last Modified By : Jason Qiu
// Last Modified On : 03-16-2018
// ***********************************************************************
// <copyright file="Program.cs" company="C">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using C.Tokenizer;
namespace C
{
    /// <summary>
    /// Class Program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("-------Viva la Vida!-------");
            //Test Tokenizer
            String sourceCode = System.IO.File.ReadAllText("./TestCode/expr1.c.txt");
            Scanner scanner = new Scanner(sourceCode);
            IList<Token> tokens = scanner.Lex();
            Console.WriteLine("-----------Source----------");
            Console.WriteLine();
            Console.WriteLine(sourceCode);
            Console.WriteLine("-------End of Source-------");
            Console.WriteLine("-----------Tokens----------");
            Console.WriteLine();
            foreach (var item in tokens)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
            Console.WriteLine("-------End of Tokens-------");
            Console.WriteLine("-------Viva la Vida!-------");
            var parser = new Parser.CParser(tokens);
            parser.Expr();
            var env = new Parser.Environment(null);
            var table = new System.Collections.Hashtable();
            table.Add(1, new Parser.Symbol(1234));
            table.Add(2, table[1]);
            ((Parser.Symbol)table[1]).i = 1;
            Console.WriteLine(((Parser.Symbol)table[1]).i);
            Console.WriteLine(((Parser.Symbol)table[2]).i);
            Console.ReadKey();
        }
    }
}
