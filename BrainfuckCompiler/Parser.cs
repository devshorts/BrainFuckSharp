using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrainfuckCompiler
{
    public enum Tokens
    {
        MoveFwd,
        MoveBack,
        Incr,
        Decr,
        While,
        Print,
        Input,
        WhileEnd,
        WhileStart,
        Unknown
    }

    public class Instruction
    {
        public Tokens Token { get; set; }

        public override string ToString()
        {
            return Token.ToString();
        }
    }

    class While : Instruction
    {
        public While()
        {
            Token = Tokens.While; 
        }

        public List<Instruction> Instructions { get; set; } 
    }


    class Parser
    {
        public List<Instruction> Instructions { get; private set; }

        public Parser(string source)
        {
            Instructions = Tokenize(source.Select(GetToken)
                                          .Where(token => token != Tokens.Unknown)
                                          .ToList()).ToList();
        }

        IEnumerable<Instruction> Tokenize(IEnumerable<Tokens> input)
        {
            var stack = new Stack<While>();

            foreach (var t in input)
            {
                switch (t)
                {
                    case Tokens.WhileStart:
                        stack.Push(new While {Instructions = new List<Instruction>()});
                        break;
                    case Tokens.WhileEnd:
                        if (stack.Count == 0)
                        {
                            throw new Exception("Found a ] without a matching [");
                        }
                        if (stack.Count > 1)
                        {
                            var top = stack.Pop();
                            stack.Peek().Instructions.Add(top);
                        }
                        else
                        {
                            yield return stack.Pop();
                        }
                        break;
                    default:
                        var instruction = new Instruction {Token = t};
                        if (stack.Count > 0)
                        {
                            stack.Peek().Instructions.Add(instruction);
                        }
                        else
                        {
                            yield return instruction;
                        }
                        break;
                }
            }

            if (stack.Count > 0)
            {
                throw new Exception("Unmatched [ found. Expecting ]");
            }
        }
        
        private Tokens GetToken(char input)
        {
            switch (input)
            {
                case '+':
                    return Tokens.Incr;
                case '-':
                    return Tokens.Decr;;
                case '<':
                    return Tokens.MoveBack;
                case '>':
                    return Tokens.MoveFwd;
                case '.':
                    return Tokens.Print;
                case ',':
                    return Tokens.Input;
                case '[':
                    return Tokens.WhileStart;
                case ']':
                    return Tokens.WhileEnd;
            }
            return Tokens.Unknown;
        }
    }
}
