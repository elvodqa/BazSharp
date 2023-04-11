namespace Baz.Compiler.AST.Nodes;

public enum ArithmeticOperator
{
    Add,
    Subtract,
    Multiply,
    Divide,
    Modulo,
    Power
}

public class BinaryExprNode : SyntaxNode
{
    public SyntaxNode Left { get; set; }
    public SyntaxNode Right { get; set; }
    public ArithmeticOperator Operator { get; set; }
    
    public BinaryExprNode(SyntaxNode left, SyntaxNode right, ArithmeticOperator op)
    {
        Left = left;
        Right = right;
        Operator = op;
        NodeType = NodeType.BinaryExpr;
    }
}