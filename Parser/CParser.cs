using System;
using System.Collections.Generic;
using System.Text;
using C.Tokenizer;
using C.AST;

namespace C.Parser
{
    class CParser
    {
        public CParser(IList<Token> tokens)
        {
            Tokens = tokens;
            Lookahead = NextTerminal();
        }
        
        public void Expr()
        {
            switch (Lookahead.Kind)
            {
                case TokenKind.INT:
                    INT();
                    Rest();
                    break;
                default:
                    break;
            }
        }

        public void INT()
        {
            if (Lookahead.Kind == TokenKind.INT)
            {
                Console.Write($"[{((TokenInt)Lookahead).Val}]");
                Lookahead = NextTerminal();
            }
            else
            {
                throw new Exception("INT not matched");
            }
            
        }

        public void Rest()
        {
            switch (Lookahead.Kind)
            {
                case TokenKind.OPERATOR:
                    switch (((TokenOperator)Lookahead).Val)
                    {
                        case OperatorVal.ADD:
                            ADD();
                            INT();
                            Console.Write("+");
                            Rest();
                            break;
                        case OperatorVal.SUB:
                            SUB();
                            INT();
                            Console.Write("-");
                            Rest();
                            break;
                        default:
                            break;

                    }
                    break;
            }
        }

        public void ADD()
        {
            Lookahead = NextTerminal();
        }

        public void SUB()
        {
            Lookahead = NextTerminal();
        }

        private IList<Token> Tokens;
        private Int32 lookaheadPosition = -1;

        private Token Lookahead;

        Token NextTerminal()
        {
            lookaheadPosition++;
            return Tokens[lookaheadPosition];
        }
        
    }
}
