namespace Baz.Compiler.AST;

public enum NodeType
{
    ConstantExpr,
    FunctionCallExpr,
    ReferenceExpr,
    IdentifierExpr,
    BinaryExpr,
    UnaryExpr,
    ElseStatement,
    IfStatement,
    BlockStatement,
    CaseStatement,
    BreakStatement,
    ContinueStatement,
    EmptyStatement,
    ForStatement,
    ReturnStatement,
    FunctionDecl,
    VariableDecl,
    StructDecl,
}