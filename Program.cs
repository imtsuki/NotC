using System;
using System.Collections.Generic;
using C.Tokenizer;
using C.AST;
namespace C
{
    public class Program
    {
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
            var a = parser.Parse();
            Console.WriteLine(a.ToString());
            
        }
    }
}
