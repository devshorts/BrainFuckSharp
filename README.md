BrainFuckSharp
==============

A brainfuck parser and interpreter.

```csharp
static void Main(string[] args)
{
    var parser = new Parser("++++++++++[>+++++++>++++++++++>+++>+<<<<-]>++.>+.+++++++..+++.>++.<<+++++++++++++++.>.+++.------.--------.>+.>.");

    var isntructions = parser.Instructions;

    var interpreter = new Interpreter(isntructions);

    interpreter.Interpret();
}
```

```
Hello World!
```

For more info on brainfuck, check out the [brainfuck wikipedia](http://en.wikipedia.org/wiki/Brainfuck). Have fun!