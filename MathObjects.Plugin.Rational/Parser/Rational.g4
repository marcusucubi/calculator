grammar Rational;

options {
    language=CSharp;
}
 
@lexer::namespace{MathObjects.Core.Parser}
@parser::namespace{MathObjects.Core.Parser}

stat    :
        expr       # printExpr
        ;

/** A rule called init that matches comma-separated values between {...}. */
expr     : 
         expr op=('*'|'/') expr    # MulDiv
         | expr op=('+'|'-') expr  # AddSub
         | tuple                   # TupleExp
         | INT                     # IntExp
         | '(' expr ')'            # Parens
         ;

tuple    : 
         '(' INT ',' INT ')' 
         ;

// parser rules start with lowercase letters, lexer rules with uppercase
INT      : [0-9]+ ;
MUL      : '*' ; // assigns token name to '*' used above in grammar
DIV      : '/' ;
ADD      : '+' ;
SUB      : '-' ;
WS       : [ \t\r\n]+ -> skip ;

