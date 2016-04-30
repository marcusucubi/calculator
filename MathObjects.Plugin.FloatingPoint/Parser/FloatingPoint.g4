grammar FloatingPoint;

options { language=CSharp; }

file        :
            stat+
            ;
   
stat        :
            expr ';'                       # printExpr
            | ID ('<-'|'=') expr ';'       # assignment
            | ';'                          # empty
            ;

/** A rule called init that matches comma-separated values between {...}. */
expr        : 
            ID '(' exprList? ')'           # FuncCall
            |<assoc=right> expr '^' expr   # Exponent
            | '-' expr                     # Negative
            | expr op=('*'|'/') expr       # MulDiv
            | expr op=('+'|'-') expr       # AddSub
            | INT                          # Int
            | FLOAT                        # Float
            | ID                           # Variable
            | STACK_PARAM                  # StackParam
            | '(' expr ')'                 # Parens
            ;

exprList    : expr (',' expr)* 
            ;

/** A value can be either a nested array/struct or a simple integer (INT) */
value       : INT
            ;

// parser rules start with lowercase letters, lexer rules with uppercase
INT         : [0-9]+ ;

FLOAT       : DIGIT+ '.' DIGIT*
            | '.' DIGIT+
            ;

ID          : LETTER+ DIGIT* ;
STACK_PARAM : '%' INT ;

DIGIT       : [0-9] ;
LETTER      : [a-zA-Z_.] ;

MUL         : '*' ; // assigns token name to '*' used above in grammar
DIV         : '/' ;
ADD         : '+' ;
SUB         : '-' ;
START       : '{' ;
END         : '}' ;

WS          : [ \t\r\n]+ -> skip ;
