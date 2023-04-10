namespace Baz.Compiler.AST;

public enum ExprType
{
    ConstantExpr,
    FunctionCallExpr,
    ReferenceExpr,
    IdentifierExpr,
    BinaryExpr,
    UnaryExpr,
}

public enum StatementType
{
    ElseStatement,
    IfStatement,
    BlockStatement,
    CaseStatement,
    BreakStatement,
    ContinueStatement,
    EmptyStatement,
    ForStatement,
    ReturnStatement,
}

public enum DeclarationType
{
    FunctionDecleration,
    VariableDecleration,
}