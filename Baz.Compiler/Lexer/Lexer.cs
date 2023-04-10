namespace Baz.Compiler.Lexer;

public class Lexer
{
    public string Source { get; }
    public int Position { get; private set; }
    public int Line { get; private set; }
    public int Column { get; private set; }
    public char Current => Source[Position];
    public char Next => Source[Position + 1];
    public bool IsAtEnd => Position >= Source.Length;

    public Lexer(string source)
    {
        Source = source;
        Position = 0;
        Line = 1;
        Column = 1;
    }

    public Token NextToken()
    {
        if (IsAtEnd)
            return new Token(TokenType.Eof, null, Line, Column);

        var c = Current;
        Position++;
        Column++;

        switch (c)
        {
            case '\n':
                Line++;
                Column = 1;
                return new Token(TokenType.NewLine, "", Line, Column);
            
            case ' ': case '\t': case '\r':
                /* This is a temporary fix for an issue.
                 * Also I don't think whitespace information is really necessary anyways. 
                 * So I'm just gonna yeet this part out.
                int numberOfSpaces = 1;
                while (Next == ' ' || Next == '\t' || Next == '\r')
                {
                    Position++;
                    Column++;
                    numberOfSpaces++;
                }
                return new Token(TokenType.WhiteSpaceTrivia, numberOfSpaces, Line, Column);
                */
                return NextToken();
            case '+': return new Token(TokenType.Plus, "+", Line, Column);
            case '-': return new Token(TokenType.Minus, "-", Line, Column);
            case '*': return new Token(TokenType.Star, "*", Line, Column);
            case '/': return new Token(TokenType.Slash, "/", Line, Column);
            case '%': return new Token(TokenType.Modulo, "%", Line, Column);
            case '(': return new Token(TokenType.LeftParen, "(", Line, Column);
            case ')': return new Token(TokenType.RightParen, ")", Line, Column);
            case '{': return new Token(TokenType.LeftBrace, "{", Line, Column);
            case '}': return new Token(TokenType.RightBrace, "}", Line, Column);
            case '[': return new Token(TokenType.LeftBracket, "[", Line, Column);
            case ']': return new Token(TokenType.RightBracket, "]", Line, Column);
            case ',': return new Token(TokenType.Comma, ",", Line, Column);
            case '.': return new Token(TokenType.Dot, ".", Line, Column);
            case ':':
                /* if (Next == ':')
                {
                    Position++;
                    Column++;
                    return new Token(TokenType.ColonColon, "::", Line, Column);
                } */
                return new Token(TokenType.Colon, ":", Line, Column);
            case ';': return new Token(TokenType.Semicolon, ";", Line, Column);
            case '!':
                if (Next == '=')
                {
                    Position++;
                    Column++;
                    return new Token(TokenType.BangEqual, "!=", Line, Column);
                }
                return new Token(TokenType.Bang, "!", Line, Column);
            
            case '=':
                if (Next == '=')
                {
                    Position++;
                    Column++;
                    return new Token(TokenType.Equal, "==", Line, Column);
                }
                return new Token(TokenType.Assign, "=", Line, Column);
            
            case '>':
                if (Next == '=')
                {
                    Position++;
                    Column++;
                    return new Token(TokenType.GreaterEqual, ">=", Line, Column);
                }
                return new Token(TokenType.Greater, ">", Line, Column);
            
            case '<':
                if (Next == '=')
                {
                    Position++;
                    Column++;
                    return new Token(TokenType.LessEqual, "<=", Line, Column);
                }
                return new Token(TokenType.Less, "<", Line, Column);
            
            case '&':
                if (Next == '&')
                {
                    Position++;
                    Column++;
                    return new Token(TokenType.And, "&&", Line, Column);
                }
                return new Token(TokenType.Error, "Unexpected character '&'", Line, Column);
            
            case '|':
                if (Next == '|')
                {
                    Position++;
                    Column++;
                    return new Token(TokenType.Or, "||", Line, Column);
                }
                return new Token(TokenType.Error, "Unexpected character '|'", Line, Column);

            // Identifier
            case char _ when char.IsLetter(c):
            {
                var start = Position - 1;
                var _column = Column;
                while (char.IsLetterOrDigit(Current))
                {
                    Position++;
                    Column++;
                }

                var length = Position - start;
                var text = Source.Substring(start, length);

                if (text == "true" || text == "false")
                    return new Token(TokenType.BooleanLiteral, bool.Parse(text), Line, Column);

                return new Token(TokenType.Identifier, text, Line, _column);
            }
            // String literal
            case '"':
            {
                var start = Position;
                var str = "";
                var _column = Column;
                while (Current != '"' && !IsAtEnd)
                {
                    str += Current;
                    Position++;
                    Column++;
                }

                Position++;
                Column++;
                return new Token(TokenType.StringLiteral, str, Line, _column);
            }
            
            // Number literal
            case char _ when char.IsDigit(c):
            {
                var start = Position - 1;
                var _column = Column;
                while (char.IsDigit(Current) || Current == '.')
                {
                    Position++;
                    Column++;
                }

                var length = Position - start;
                var text = Source.Substring(start, length);
                return new Token(TokenType.NumberLiteral, float.Parse(text), Line, _column);
            }
            default:
                return new Token(TokenType.Error, null, Line, Column);
        }
    }

    public override string ToString()
    {
        return $"Line: {Line}, Column: {Column}";
    }

}