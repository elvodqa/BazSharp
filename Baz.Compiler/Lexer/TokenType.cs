namespace Baz.Compiler;

public enum TokenType
{
    Identifier,
    Function,
    If,
    Else,
    For,
    Plus,
    Minus, // -
    Star, // *
    Slash, // /
    Modulo, // %
    Bang, // !
    BangEqual, // !=
    Equal, // =
    EqualEqual, // ==
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
    Semicolon, // ;
    String, 
    Number,
    True,
    False,
    Null,
    Let,
    Eof
}