namespace Baz.Compiler.AST;

public enum ExprType
{
    BinaryExpr,
    PackageExpr,
    ImportExpr,
    FunctionExpr,
    VariableExpr,
    BlockExpr, // { }
    IfExpr, 
    ForExpr,
    StructExpr,
    EnumExpr,
}