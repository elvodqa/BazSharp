
using Baz.Compiler.Lexer;

string Source = File.ReadAllText(args[0]);

Lexer Lexer = new Lexer(Source);

while (true)
{
    Token Token = Lexer.NextToken();

    if (Token.Type == TokenType.Eof)
        break;

    if (Token.Type != TokenType.NewLine && Token.Type != TokenType.WhiteSpaceTrivia)
    {
        Console.WriteLine($"[{Token.Line}:{Token.Column}] {Token}");
    }
        
}