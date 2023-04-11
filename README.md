# Baz

Baz is a programming language heavily inspired by Odin/JAI. It's made joy of programming in mind and tries to eliminate boring practices and make programming fun.
Current [spesification](spesification.md) is available.

### Progress

- [x] Lexer
- [ ] Parser
- [ ] Basic C0 transpiler
- [ ] Implement all language features
- [ ] Optimize transpiler
- [ ] Bootstrapping

##  Example

```odin
package main;

import "core:fmt";

vec2 :: struct {
    x: int,
    y: int,
}

PI :: 3.14159265359;

main :: fn() {
    mut myVec : vec2 = {
        x: 0,
        y: 10,
    };
    
    for i := 0; i < 10; i++ {
        myVec.x += i;
    }
    
    fmt.println(myVec.x);
}
```
