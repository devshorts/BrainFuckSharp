using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrainfuckCompiler
{
    public class Interpreter
    {
        private readonly byte[] _space = new byte[30000];

        private int _dataPointer;

        private List<Instruction> Instructions { get; set; }
        
        public Interpreter (List<Instruction> instructions)
        {
            Instructions = instructions;
        }

        public void Interpret()
        {
            InterpretImpl(Instructions);
        }

        private void InterpretImpl(IEnumerable<Instruction> instructions)
        {
            foreach(var instruction in instructions){
                switch (instruction.Token)
                {
                    case Tokens.Input:
                        _space[_dataPointer] = Convert.ToByte(Console.Read());
                        break;
                    case Tokens.Incr:
                        _space[_dataPointer]++;
                        break;
                    case Tokens.Decr:
                        _space[_dataPointer]--;
                        break;
                    case Tokens.Print:
                        Console.Write(Encoding.ASCII.GetString(new[] { _space[_dataPointer] }));
                        break;
                    case Tokens.MoveFwd:
                        _dataPointer++;
                        break;
                    case Tokens.MoveBack:
                        _dataPointer--;
                        break;
                    case Tokens.While:
                        while (_space[_dataPointer] != 0)
                        {
                            InterpretImpl((instruction as While).Instructions);
                        }
                        break;
                }
            }
        }
    }
}
