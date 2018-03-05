using System;
using System.Collections.Generic;
namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            String sourceCode = @"char num[20];
char stack[20];
char *p = stack;
int rnum = '0';
char a = '\n';
void push(char n) {
    *p = n;
    p++;
}

char pop() {
    p--;
    return *p;
}

void plus(int n) {
    
    rnum *= 10;
    rnum += n;
}

int main(){
    int n = strlen(num);
            for (int i = 0; i < n / 2; i++)
            {
                push(num[i]);
                plus(num[i] - 0);
            }
            if (n % 2 == 1)
            {
                plus(num[n / 2] - 0);
                n++;
            }
            char c;
            for (int i = n / 2; i < n - 1; i++)
            {
                c = pop();
                if (c != num[i])
                {
                    goto NO;
                }
                plus(num[i] - 0);
            }

            if ((int)sqrt(rnum) * (int)sqrt(rnum) == rnum)
                goto YES;
            else
                goto NO;
            YES:

            return 0;
            NO:


            return 0;

        }
";
            Console.WriteLine("-------Viva la Vida!-------");
            LexicalScanner scanner = new LexicalScanner(sourceCode);
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
