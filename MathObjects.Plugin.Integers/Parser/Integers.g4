grammar Integers;

options {
    language=CSharp;
}
 
@lexer::namespace{MathObjects.Core.Parser}
@parser::namespace{MathObjects.Core.Parser}

stat     :
         expr       # printExpr
         ;

/** A rule called init that matches comma-separated values between {...}. */
expr     : 
         ID '(' exprList? ')'           # FuncCall
         |<assoc=right> expr '^' expr   # Exponent
         | '-' expr                     # Negative
         | expr '*' expr                # MulDiv
         | expr '+' expr                # Add
         | expr SUB expr                # Sub
         | INT                          # Int
         | '(' expr ')'                 # Parens
         ;

exprList : expr (',' expr)* 
         ;

/** A value can be either a nested array/struct or a simple integer (INT) */
value    : INT
         ;

// parser rules start with lowercase letters, lexer rules with uppercase
INT      : [0-9]+ ;

DIGIT    : [0-9] ;
LETTER   : [a-zA-Z\u0080-\u00FF_] ;

ID       : LETTER (LETTER|DIGIT)* ;

TOP      : 'top' ;
MUL      : '*' ; // assigns token name to '*' used above in grammar
ADD      : '+' ;
SUB      : '-' ;

WS       : [ \t\r\n]+ -> skip ;
