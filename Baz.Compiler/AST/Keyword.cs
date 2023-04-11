using System.ComponentModel;

namespace Baz.Compiler.AST;

public enum Keyword
{
    [Description("u8")]
    u8, 
    [Description("u16")]
    u16,
    [Description("u32")]
    u32,
    [Description("u64")]
    u64,
    [Description("i8")]
    i8,
    [Description("i16")]
    i16,
    [Description("i32")]
    i32,
    [Description("i64")]
    i64,
    [Description("f32")]
    f32,
    [Description("f64")]
    f64,
    [Description("int")]
    int_,
    [Description("uint")]
    uint_,
    [Description("byte")]
    byte_,
    [Description("bool")]
    bool_,
    [Description("str8")]
    str8,
    [Description("str16")]
    str16,
    [Description("string")]
    string_,
    [Description("nil")]
    nil,
    [Description("struct")]
    struct_,
    [Description("enum")]
    @enum,
    [Description("union")]
    union,
    [Description("fn")]
    fn,
    [Description("import")]
    import,
    [Description("package")]
    package,
    [Description("mut")]
    mut
}