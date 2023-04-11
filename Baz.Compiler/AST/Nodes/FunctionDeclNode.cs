namespace Baz.Compiler.AST.Nodes;

public class FunctionDeclNode : SyntaxNode
{
    public string Name { get; set; }
    public string ReturnType { get; set; }
    public string[] Parameters { get; set; }
    public SyntaxNode[] Body { get; set; }
    
    public FunctionDeclNode()
    {
        NodeType = NodeType.FunctionDecl;
    }
}