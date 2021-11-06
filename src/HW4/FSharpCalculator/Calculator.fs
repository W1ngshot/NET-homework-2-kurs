namespace FSharpCalculator
module Calculator = 
    let calculate (arg1:double) (operation:char) (arg2:double) =
        match operation with
        | '+' -> arg1 + arg2
        | '-' -> arg1 - arg2
        | '*' -> arg1 * arg2
        | '/' -> arg1 / arg2