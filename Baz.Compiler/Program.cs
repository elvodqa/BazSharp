
using Baz.Compiler.AST;
using Baz.Compiler.Lexer;

string Source = File.ReadAllText(args[0]);

Lexer Lexer = new Lexer(Source);
Parser Parser = new Parser(Lexer);

List<SyntaxNode> Nodes = Parser.Parse();
foreach (SyntaxNode Node in Nodes)
{
    Console.WriteLine(Node);
}