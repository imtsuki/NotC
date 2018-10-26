using System;
using System.Linq;
using System.Collections.Generic;
using NotC.LexicalAnalysis;
using NotC.SyntaxAnalysis;

namespace NotC {
    public class Printer {
        public static void PrintSyntaxTree(SyntaxNode root) {
            Console.WriteLine(root.ToString());
            foreach (var child in root.Children()) {
                PrintSyntaxTree(child);
            }
        }

        public static void PrintAST() {

        }
    }
}