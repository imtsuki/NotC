// ***********************************************************************
// Assembly         : C
// Author           : super
// Created          : 03-06-2018
//
// Last Modified By : super
// Last Modified On : 03-06-2018
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
    class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("-------Viva la Vida!-------");
            //Test Tokenizer
            String sourceCode = System.IO.File.ReadAllText("./TestCode/lex.c.txt");
            Scanner scanner = new Scanner(sourceCode);
            IEnumerable<Token> tokens = scanner.Lex();
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
            Console.ReadKey();
        }
    }
}
