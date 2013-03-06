namespace BrainfuckCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new Parser("++++++++++[>+++++++>++++++++++>+++>+<<<<-]>++.>+.+++++++..+++.>++.<<+++++++++++++++.>.+++.------.--------.>+.>.");

            var isntructions = parser.Instructions;

            var interpreter = new Interpreter(isntructions);

            interpreter.Interpret();
        }
    }
}
