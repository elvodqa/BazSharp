namespace Baz.Compiler.AST.Nodes;

public class FunctionCallNode : SyntaxNode
{
    public string Name { get; set; }
    public SyntaxNode[] Arguments { get; set; }
    
    public FunctionCallNode()
    {
        NodeType = NodeType.FunctionCallExpr;
    }
}