namespace Baz.Compiler.Lexer;

public class Token
{
    public readonly TokenType Type;
    public object? Value;
    public int Line;
    public int Column;
    
    public Token(TokenType type, object? value, int line, int column)
    {
        Type = type;
        Value = value;
        Line = line;
        Column = column;
    }
    
    public override string ToString()
    {
        return $"Token({Type}, '{Value}')";
    }
}