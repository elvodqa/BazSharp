# Baz Language Spesification - v0.0.1

Baz is a programming language heavily inspired by Odin/JAI. It's made joy of programming in mind and tries to eliminate boring practices and make programming fun. 

## Types

### Numberic Types

```cpp
u8 u16 u32 u64
i8 i16 i32 i64
f16 f32 f64
int uint // depends on OS, int32 if 32 bit, int64 if 64 bit
byte rune
```

###  Boolean Types

```cpp
bool // true or false
```

### String Types

```cpp
str8 str16 str32
string :: str8 // Alias for utf-8 string
```

### Array Types

```cpp
[ArraySize]ArrayType // eg: [255]f32
```

#### Dynamic Array Types
Note: Dynamic arrays might not be supported. Just out of spite. 
```cpp
[dynamic]ArrayType // eg: [dynamic]f32
```

### Null Types

```go
nil
a := nil; // a is a null pointer
```

### Slice Types

```cpp
[]SliceType // eg: []f32
```

### Struct Types

```cpp
// An empty struct.
Foo :: struct {}

// A struct with fields
Foo :: struct {
    x, y: i32,
    u: f32,
    A: ^[]i32,
}
```

#### Generic Struct Types
Note: Syntax might change. (Most probably)
```cpp
Foo :: <T>struct {
    x, y: T,
    u: f32,
    A: ^[]T,
}
```

### Pointer Types

```cpp
[N]T //Fixed size array, behaves like a struct with N fields of type T
[]T //Slice
^T //Immutable pointer
*T //Mutable pointer

// for reference, use the & operator as always
```

Note: I might change mutable pointer to use a syntax similar to this.
Most probably I won't. Just a self note.
```c++
mut *T //Mutable pointer 
```

### Function Types

```cpp
foo :: fn()
foo :: fn(x: i32)
foo :: fn(x: i32) => bool
foo :: fn(x: i32) => (bool)
foo :: fn(x: i32, values: ...i32) => (bool, ^[4]f32)
```

## Type Declarations

```cpp
foo: i32; // immutable 
mut foo: i32; // mutable 
foo: i32 : 1; // constant
foo :: 1; // constant and type is inferred by the compiler
foo := 1; // immutable and type is inferred by the compiler
```

## Method Declarations

```cpp
Add :: fn(x, y: i32) => i32 {
    return x + y;
}

Clear :: fn(flags: GL_ENUM) {
    gl.Clear(flags)
}
```

## Enum Declarations

```cpp
Color :: enum {
    Black, // 0
    White, // 1
    Red, // 2
    Blue, // 3
}
```

###  Indexing Array with Enums

```cpp
ColorToRGB8 :: [Color]RGB8 {
    .Black = {0, 0, 0},
    .Red = {255, 0, 0},
    .Green = {0, 255, 0},
    .Blue = {0, 0, 255},
    .White = {255, 255, 255},
}

// Classic enums
Colour :: enum
{
  Black,
  White,
}

ColourToString :: [Colour]str
{
  .Black = "Black",
  .White = "White",
}

c := Colour.Black;

print(c->ColourToString[]);
```

## Union Declarations

TODO: Improve(?)

```cpp
// cUnions are C equivalent they do not support switch statements or checks for type errors
// all access to them is equivalent to c++ reinterpret_cast
Foo :: cUnion {
    i32,
    f32,
    str,
}
// trackedUnions have a architecture-word sized identifier at the offset 0 
// which allows for runtime typechecking and switch is statements
Bar :: trackedUnion{
    // *hidden* ID:int
    i32,
    f32,
    str
}
//Can also use named variants:
namedUnion :: cUnion
{
  Number : int,
  OtherNumber : int,
  Name : string,
  Id : GUID,
}

Shape :: trackedUnion
{
  Square,
  Rectangle,
  Hexagon,
  Triangle,
}

//Any expression which unwraps a union also gives us a contextual "this".

triangle : Shape = Triangle{} 

switch triangle // only possible because Shape is trackedUnion
{
  is Square    => panic()
  is Rectangle => panic()
  is Triangle  => typeof(this)->print() //"this" in this case is a reference to the union's "data" of type Triangle.
                                       //We then get the type and print it.
  is Hexagon   => panic()
}

```

## Generics Declarations

```rust
generic_func :: <T>(param : T) T
{}
//Or, form for when the types are deducible:
generic_func :: (param : $T) T
{}
```

## Type Aliases

```cpp
someType :: f32
// keyword 'distinct' is optional
Position :: distinct [3]f32;
Velocity :: distinct [3]f32;

a : Position = Velocity{1, 2, 3}; //Type mismatch, compilation error.
```

## Type Casting

```cpp
i32(x)
```

##  Conditional Statements

```cpp
if x == 1 {
    // do something
} else if x == 2 {
    // do something else
} else {
    // do something else
}

// When is a compile time "if"
when x {
    1 => {
        // do something
    }
    2 => {
        // do something else
    }
    _ => {
        // default
    }
}
```

## Custom Operators

```cpp
operator + :: fn(a, b : quaternion) => quaternion {}

myQuat := a + b;
```

###  Defer

```cpp
a := 1;
defer print(a);
b := 2;
defer print(b);
c := 3;
defer print(c);
//Defer statements get executed at the end of the scope they were declared in.
//Defer statements get executed in reverse order.
//Will print 3, then 2, then 1.
```

###  Pipe Operator

```cpp
toString :: fn(a : int) => string
{}

a := 129;

//With the pipe operator we can turn this:
print(toString(a));

//To this:
print(a->toString());

//Or even this:
a->toString()->print();
```

## Switches

```cpp
switch someEnum
{
  is A => fmt.print("A"),
  is B => fmt.print("B"),
  is C => fmt.print("C"),
  is D => fmt.print("D"),
}

//Switches are expressions and can therefore produce a value.
n : int = switch someEnum
{
  is A => 61,
  is B => 21,
  is C => 34,
  is D => 0,
}
```
