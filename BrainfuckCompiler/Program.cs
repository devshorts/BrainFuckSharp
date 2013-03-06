namespace BrainfuckCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new Parser("++++++++++[>+++++++>++++++++++>+++>+<<<<-]>++.>+.+++++++..+++.>++.<<+++++++++++++++.>.+++.------.--------.>+.>.");

            var instructions = parser.Instructions;

            var interpreter = new Interpreter(instructions);

            interpreter.Interpret();
        }
    }
}
