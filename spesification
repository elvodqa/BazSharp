# Baz Language (0.0.1) Spesification

Baz is a programming language design around the idea of how much other languages suck at some things.

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
str // utf 8 string 
```

### Array Types

```cpp
[ArraySize]ArrayType // eg: [255]f32
```

### Null Types

```go
nil 
a := nil // a is a null pointer
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
    x, y: i32
    u: f32
    A: ^[]i32
    F: fn()
}
```

#### Generic Struct Types

```cpp
Foo :: <T>struct {
    x, y: T
    u: f32
    A: ^[]T
    F: fn()
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

### Function Types

```cpp
foo :: fn()
foo :: fn(x: i32)
foo :: fn(x: i32) bool
foo :: fn(x: i32) (bool)
foo :: fn(x: i32, values: ...i32) (bool, ^[4]f32)
```

## Type Declarations

```cpp
foo: i32 // immutable 
mut foo: i32 // mutable 
foo: i32 : 1 // constant
foo := 1 // immutable and type is inferred by the compiler
```

## Method Declarations

```cpp
Add :: fn(x, y: i32) i32 {
    return x + y
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

###  Indexing Array with Enum

```cpp
ColorToRGB8 :: [Color]RGB8 {
    .Black = {0, 0, 0},
    .Red = {255, 0, 0},
    .Green = {0, 255, 0},
    .Blue = {0, 0, 255},
    .White = {255, 255, 255},
}

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

c := Colour.Black

print(c->ColourToString[])
```

## Union Declarations

TODO: Improve(?)

```cpp
Foo :: union {
    i32,
    f32,
    str,
}

//Can also use named variants:
namedUnion :: union
{
  Number : int,
  OtherNumber : int,
  Name : string,
  Id : GUID,
}

Shape :: union
{
  Square,
  Rectangle,
  Hexagon,
  Triangle,
}

//Any expression which unwraps a union also gives us a contextual "this".

triangle : Shape = Triangle{} 

switch triangle
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
Position :: distinct [3]f32
Velocity :: distinct [3]f32

a : Position = Velocity{1, 2, 3} //Type mismatch, compilation error.
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
when x == 1 {
    // do something
} else when x == 2 {
    // do something else
} else {
    // do something else
}

when x {
    1 => {
        // do something
    }
    2 => {
        // do something else
    }
    _ => {
        // do something else
    }
}
```

## Custom Operators

```cpp
operator + :: fn(a, b : quaternion) => quaternion {}

myQuat := a + b

//Treating them like functions also lets us use packages to disambiguate when needed.
myQuat := a koziMath.+ b

//Can use the using_ops statement to only pull a package's operators directly into current scope

package EpicMath
operator * :: fn(a, b : quaternion) => quaternion {}
doMath :: fn(value : quaternion) => f32 {}

//Some other file in a different package...
import "EpicMath"

q := a EpicMath.+ b

//Or this!
using_ops EpicMath

q := a + b                   //Now we don't need to fully qualify the op.
scalar := EpicMath.doMath(q) //Still need to qualify normal functions.
```

###  Defer

```cpp
a := 1
defer print(a)
b := 2
defer print(b)
c := 3
defer print(c)
//Defer statements get executed at the end of the scope they were declared in.
//Defer statements get executed in reverse order.
//Will print 3, then 2, then 1.
```

###  Pipe Operator

```cpp
toString :: fn(a : int) => string
{}

a := 129

//With the pipe operator we can turn this:
print(toString(a))

//To this:
print(a->toString())

//Or even this:
a->toString()->print()
```

## Switches

```cpp
switch someEnum
{
  is A => print("A"),
  is B => print("B"),
  is C => print("C"),
  is D => print("D"),
}

//Switches are expressions and can therefore produce a value.
n : int = switch someEnum
{
  is A => 129,
  is B => 991,
  is C => 1822,
  is D => -12,
}
```
