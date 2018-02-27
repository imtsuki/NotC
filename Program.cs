using System;
using System.Collections.Generic;
namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            String sourceCode = @"
int main() {
    int a, b, c;
    a = b + c;
    return a;
}
";
            LexicalScanner scanner = new LexicalScanner(sourceCode);
            IEnumerable<Token> tokens = scanner.Lex();
            Console.WriteLine("Source Code:");
            Console.WriteLine(sourceCode);
            Console.WriteLine("Tokens:");
            foreach (var item in tokens)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
