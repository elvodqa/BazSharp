namespace Baz.Compiler.Lexer;

public enum TokenType
{
    Identifier,
    Plus,
    Minus, // -
    Star, // *
    Slash, // /
    Modulo, // %
    Bang, // !
    BangEqual, // !=
    Assign, // =
    Equal, // ==
    Greater, // >
    GreaterEqual, // >=
    Less, // <
    LessEqual, // <=
    And, // &&
    Or, // ||
    LeftParen, // (
    RightParen, // )
    LeftBrace, // {
    RightBrace, // }
    LeftBracket, // [
    RightBracket, // ]
    Comma, // ,
    Dot, // .
    Colon, // :
    ColonColon, // ::
    Semicolon, // ;
    StringLiteral, 
    NumberLiteral,
    BooleanLiteral,
    NewLine,
    Error,
    WhiteSpaceTrivia,
    Eof
}