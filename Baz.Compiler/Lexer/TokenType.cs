namespace Baz.Compiler.Lexer;

public enum TokenType
{
    Identifier,
    Plus,
    Minus, // -
    Star, // *
    Slash, // /
    SlashSlash, // //
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
    Eof,
    
    // Keywords
    Package,
    Import,
    Fn,
    Struct,
    Mut,
    Enum,
    Union,
    Nil,
    Break,
    Continue,
    Switch,
    Case,
    When,
    If,
    Else,
    For,
    Default,
    Is,
    Distinct,
    Proc,
}