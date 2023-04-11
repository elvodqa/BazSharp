using Baz.Compiler.Lexer;

namespace Baz.Compiler.AST;

public class SyntaxNode
{
    public SyntaxNode Parent { get; set; }
    public SyntaxNode[] Children { get; set; }
    public NodeType NodeType { get; set; }
    public List<Token> Tokens { get; set; }
    public int Line { get; set; }
    public int Column { get; set; }
    public string Source { get; set; }
}