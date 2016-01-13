grammar Permutation;     

options {
    language=CSharp;
}
 
@lexer::namespace{MathObjects.Core.Parser}
@parser::namespace{MathObjects.Core.Parser}

/** A rule called init that matches comma-separated values between {...}. */
init    : 
        '(' value (',' value)* ')' 
        | '(' ')' 
        ;

/** A value can be either a nested array/struct or a simple integer (INT) */
value   : INT
        ;

// parser rules start with lowercase letters, lexer rules with uppercase
INT     : [0-9]+ ;
WS      : [ \t\r\n]+ -> skip ;

