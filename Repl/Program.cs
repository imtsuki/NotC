using System;
using System.Collections.Generic;
using System.Linq;
using NotC.Tokenizer;
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
                var scanner = new Scanner(input);
                var tokens = scanner.Lex();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                foreach (var token in tokens) {
                    Console.WriteLine(token.ToString());
                }
                Console.ResetColor();
                if (scanner.LexErrors.Any()) {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    foreach (var message in scanner.LexErrors) {
                        Console.WriteLine($"ERROR: {message}");
                    }
                    Console.ResetColor();
                }
                var parser = new Parser.CParser(tokens);
                var result = parser.Expr();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(result.ToString());
                Console.ResetColor();
            }
        }
    }
}
