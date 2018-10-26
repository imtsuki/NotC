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
                var scanner = new Scanner(input);
                var tokens = scanner.Scan();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                foreach (var token in tokens) {
                    Console.WriteLine($"{token.ToString()} {token.Position} {token.Length}");
                }
                Console.ResetColor();
                if (scanner.ErrorMessage.Any()) {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    foreach (var message in scanner.ErrorMessage) {
                        Console.WriteLine($"ERROR: {message}");
                    }
                    Console.ResetColor();
                }
                var parser = new Parser(input);
                var result = parser.Expr();
                if (parser.ErrorMessage.Any()) {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    foreach (var message in parser.ErrorMessage) {
                        Console.WriteLine($"ERROR: {message}");
                    }
                    Console.ResetColor();
                }
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(result.ToString());
                Console.ResetColor();
            }
        }
    }
}
