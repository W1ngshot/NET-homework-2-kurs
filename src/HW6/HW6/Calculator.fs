namespace HW6

module Calculator = 
    let calculate (arg1:decimal, operation:char, arg2:decimal) =
        match operation with
        | '^' -> arg1 + arg2
        | '-' -> arg1 - arg2
        | '*' -> arg1 * arg2
        | '/' -> arg1 / arg2