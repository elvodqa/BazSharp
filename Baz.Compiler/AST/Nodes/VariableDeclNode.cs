namespace Baz.Compiler.AST.Nodes;

public class VariableDeclNode : SyntaxNode
{
    public bool Mutable { get; set; }
    public bool Constant { get; set; }
    public bool Inferred { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public SyntaxNode Value { get; set; }
    
    public VariableDeclNode()
    {
        NodeType = NodeType.VariableDecl;
    }
}