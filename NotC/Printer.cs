using System;
using NotC.SyntaxAnalysis;

namespace NotC
{
    public sealed class Printer {
        public static void PrintSyntaxTree(SyntaxNode root, string indent = "") {
            Console.WriteLine($"{indent}{root}");
            foreach (var child in root.Children()) {
                PrintSyntaxTree(child, indent + "  ");
            }
        }

        public static void PrintAST() {

        }
    }
}