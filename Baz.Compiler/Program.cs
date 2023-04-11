
using Baz.Compiler.AST;
using Baz.Compiler.Lexer;

string Source = File.ReadAllText(args[0]);


while (true)
{
    Console.Write("Baz> ");
    var input = Console.ReadLine();
    Lexer Lexer = new Lexer(input);
    while (true)
    {
        var token = Lexer.NextToken();
        if (token.Type == TokenType.Eof)
        {
            break;
        }
        Console.WriteLine(token);
    }
}