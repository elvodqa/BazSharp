namespace Baz.Compiler.AST.Nodes;

public class StructNode : SyntaxNode
{
    public string Name { get; set; }
    public string[] Fields { get; set; }
    
    public StructNode()
    {
        NodeType = NodeType.StructDecl;
    }
}