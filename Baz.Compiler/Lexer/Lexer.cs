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
                 * Ok we ballin' now. ColonColon is not a thing anymore.
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
                
                while (!IsAtEnd && char.IsLetterOrDigit(Current))
                {
                    Position++;
                    Column++;
                }

                var length = Position - start;
                var text = Source.Substring(start, length);

                switch (text)
                {
                    case "true":
                    case "false":
                        return new Token(TokenType.BooleanLiteral, bool.Parse(text), Line, Column);
                    case "nil":
                        return new Token(TokenType.Nil, null, Line, Column);
                    case "fn":
                        return new Token(TokenType.Fn, null, Line, Column);
                    case "mut":
                        return new Token(TokenType.Mut, null, Line, Column);
                    case "if":
                        return new Token(TokenType.If, null, Line, Column);
                    case "else":
                        return new Token(TokenType.Else, null, Line, Column);
                    case "for":
                        return new Token(TokenType.For, null, Line, Column);
                    case "package":
                        return new Token(TokenType.Package, null, Line, Column);
                    case "import":
                        return new Token(TokenType.Import, null, Line, Column);
                    case "struct":
                        return new Token(TokenType.Struct, null, Line, Column);
                    case "enum":
                        return new Token(TokenType.Enum, null, Line, Column);
                    case "union":
                        return new Token(TokenType.Union, null, Line, Column);
                    case "break":
                        return new Token(TokenType.Break, null, Line, Column);
                    case "continue":
                        return new Token(TokenType.Continue, null, Line, Column);
                    case "switch":
                        return new Token(TokenType.Switch, null, Line, Column);
                    case "case":
                        return new Token(TokenType.Case, null, Line, Column);
                    case "default":
                        return new Token(TokenType.Default, null, Line, Column);
                    case "when":
                        return new Token(TokenType.When, null, Line, Column);
                    case "is":
                        return new Token(TokenType.Is, null, Line, Column);
                    default:
                        return new Token(TokenType.Identifier, text, Line, _column);
                }
            }
                
            /* TODO: 
            * Error eg:
             * Given> "Hello" World"
             * This lexes to ["Hello", "World", ""] WTF!?!
            */
            // String literal
            case '"':
            {
                var start = Position;
                var str = "";
                var _column = Column;
                while (!IsAtEnd && Current != '"')
                {
                    str += Current;
                    Position++;
                    Column++;
                }

                Position += 2;
                Column += 2;,
                
                return new Token(TokenType.StringLiteral, str, Line, _column);
            }
        
           
            // Number literal
            case char _ when char.IsDigit(c):
            {
                var start = Position - 1;
                var _column = Column;
                var hasDecimal = false;
                while (!IsAtEnd && char.IsDigit(Current) || Current == '.')
                {
                    if (Current == '.')
                    {
                        if (hasDecimal)
                            return new Token(TokenType.Error, "Unexpected character '.'", Line, Column);
                        hasDecimal = true;
                    }
                    Position++;
                    Column++;
                }

                var length = Position - start;
                var text = Source.Substring(start, length);
                if (hasDecimal)
                    return new Token(TokenType.NumberLiteral, float.Parse(text), Line, _column);
                return new Token(TokenType.NumberLiteral, int.Parse(text), Line, _column);

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