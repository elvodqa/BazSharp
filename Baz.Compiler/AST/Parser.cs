using Baz.Compiler.AST.Nodes;
using Baz.Compiler.Lexer;

namespace Baz.Compiler.AST;

public class Parser
{
    private readonly Lexer.Lexer _lexer;
    private List<Token> _tokens;
    private Token _currentToken;
    private int _currentTokenIndex;
    private int _prevTokenLine = 1;

    public Parser(Lexer.Lexer lexer)
    {
        _lexer = lexer;
        _tokens = new List<Token>();
        _currentTokenIndex = 0;
        _currentToken = _lexer.NextToken();
        while (_currentToken.Type != TokenType.Eof)
        {
            _tokens.Add(_currentToken);
            _currentToken = _lexer.NextToken();
        }
    }
    
    private void Error(Token token, string message)
    {
        throw new Exception($"Error at {token.Line}:{token.Column}: {message}");
    }
    
    private void Eat(TokenType tokenType)
    {
        if (_currentToken.Type == tokenType)
        {
            _currentToken = _lexer.NextToken();
        }
        else
        {
            Error(_currentToken, $"Expected token type {tokenType}, got {_currentToken.Type}");
        }
    }

    public List<SyntaxNode> Parse()
    {
        List<SyntaxNode> nodes = new List<SyntaxNode>();
        while (_currentToken.Type != TokenType.Eof)
        {
            _currentToken = _tokens[_currentTokenIndex];
            switch (_currentToken.Type)
            {
               // package name;
                case TokenType.Identifier: 
                    if (_currentToken.Value == "package")
                    { 
                        _currentTokenIndex++; 
                        _currentToken = _tokens[_currentTokenIndex];
                        if (_currentToken.Type == TokenType.Identifier)
                        {
                            var packageNode = new PackageExprNode();
                            packageNode.Name = (string)_currentToken.Value;
                            _currentTokenIndex++;
                            _currentToken = _tokens[_currentTokenIndex];
                            if (_currentToken.Type == TokenType.Semicolon)
                            {
                                _currentTokenIndex++;
                                _currentToken = _tokens[_currentTokenIndex];
                                nodes.Add(packageNode);
                            }
                            else
                            {
                                Error(_currentToken, "Expected semicolon");
                            }
                        }
                        else
                        {
                            Error(_currentToken, "Expected identifier");
                        }
                    }
                    else if (_currentToken.Value == "import")
                    {
                        _currentTokenIndex++;
                        _currentToken = _tokens[_currentTokenIndex];
                        if (_currentToken.Type == TokenType.Identifier)
                        {
                            var importNode = new ImportExprNode();
                            importNode.Name = (string)_currentToken.Value;
                            _currentTokenIndex++;
                            _currentToken = _tokens[_currentTokenIndex];
                            if (_currentToken.Type == TokenType.Semicolon)
                            {
                                _currentTokenIndex++;
                                _currentToken = _tokens[_currentTokenIndex];
                                nodes.Add(importNode);
                            }
                            else
                            {
                                Error(_currentToken, "Expected semicolon");
                            }
                        }
                        else
                        {
                            Error(_currentToken, "Expected identifier");
                        }
                    } 
                    if (_currentToken.Value == "fn")
                    {
                        _currentTokenIndex++;
                        _currentToken = _tokens[_currentTokenIndex];
                        if (_currentToken.Type == TokenType.Identifier)
                        {
                            var fnNode = new FunctionDeclNode();
                            fnNode.Name = (string)_currentToken.Value;
                            _currentTokenIndex++;
                            _currentToken = _tokens[_currentTokenIndex];
                            if (_currentToken.Type == TokenType.LeftParen)
                            {
                                _currentTokenIndex++;
                                _currentToken = _tokens[_currentTokenIndex];
                                if (_currentToken.Type == TokenType.RightBrace)
                                {
                                    _currentTokenIndex++;
                                    _currentToken = _tokens[_currentTokenIndex];
                                    if (_currentToken.Type == TokenType.LeftBrace)
                                    {
                                        _currentTokenIndex++;
                                        _currentToken = _tokens[_currentTokenIndex];
                                        if (_currentToken.Type == TokenType.RightBrace)
                                        {
                                            _currentTokenIndex++;
                                            _currentToken = _tokens[_currentTokenIndex];
                                            nodes.Add(fnNode);
                                        }
                                        else
                                        {
                                            Error(_currentToken, "Expected close brace");
                                        }
                                    }
                                    else
                                    {
                                        Error(_currentToken, "Expected open brace");
                                    }
                                }
                                else
                                {
                                    Error(_currentToken, "Expected close paren");
                                }
                            }
                            else
                            {
                                Error(_currentToken, "Expected open paren");
                            }
                        }
                        else
                        {
                            Error(_currentToken, "Expected identifier");
                        }
                    }
                    break;
               case TokenType.NewLine:
                    _currentTokenIndex++;
                    break;
                default:
                    Error(_currentToken, "Unexpected token");
                    break;
            }
        }
        return nodes;
    }
    
    
    
    
}