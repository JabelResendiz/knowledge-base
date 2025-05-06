%option c++
%{
#include <iostream>
#include <string>

// Definimos una clase para el lexer
class Lexer {
public:
    static int yylex();
};

%}

// Definición de tokens
DIGIT   [0-9]+
ID      [a-zA-Z_][a-zA-Z0-9_]*

%%

// Reglas léxicas
{DIGIT}    { std::cout << "Número: " << yytext << std::endl; }
{ID}       { std::cout << "Identificador: " << yytext << std::endl; }
[ \t\n]+   { /* Ignorar espacios y saltos de línea */ }
.          { std::cout << "Carácter desconocido: " << yytext << std::endl; }

%%

// Implementación del analizador léxico
int Lexer::yylex() {
    return yylex();
}
