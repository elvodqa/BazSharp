namespace Baz.Compiler.AST;

public enum ExprType
{
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