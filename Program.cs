using System;
using System.Collections.Generic;
namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            String sourceCode = @"+ - * / | & ^ << >> += -= *= /= |= &= ^= <<= >>=";
            LexicalScanner scanner = new LexicalScanner(sourceCode);
            IEnumerable<Token> tokens = scanner.Lex();
            foreach (var item in tokens)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
