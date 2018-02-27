using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            String sourceCode = @"
int main() {
    return 0;
}
";
            LexicalScanner scanner = new LexicalScanner(sourceCode);
            Console.WriteLine("Hello World!");
        }
    }
}
