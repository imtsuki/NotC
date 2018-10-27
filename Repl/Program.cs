using System;
using System.Collections.Generic;
using System.Linq;
using NotC.LexicalAnalysis;
using NotC.SyntaxAnalysis;
using NotC.AST;
namespace NotC
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("> ");
                String input = Console.ReadLine();
                if (input == ":q") {
                    break;
                }
                if (input == "") {
                    continue;
                }
                var parser = new Parser(input);
                var result = parser.Parse();
                if (parser.ErrorMessage.Any()) {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    foreach (var message in parser.ErrorMessage) {
                        Console.WriteLine($"ERROR: {message}");
                    }
                    Console.ResetColor();
                }
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Printer.PrintSyntaxTree(result); 
                Console.ResetColor();
            }
        }
    }
}
