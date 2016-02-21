grammar Widgets;

options {
    language=CSharp;
}

stat     :
         expr       # printExpr
         ;










expr     : 
         ID '(' exprList? ')'           # FuncCall
         | '-' expr                     # Negative
         | INT                          # Int
         | '(' expr ')'                 # Parens
         ;

exprList : expr (',' expr)* 
         ;

value    : INT
         ;

INT      : [0-9]+ ;

DIGIT    : [0-9] ;
LETTER   : [a-zA-Z\u0080-\u00FF_] ;

ID       : LETTER (LETTER|DIGIT)* ;

WS       : [ \t\r\n]+ -> skip ;
