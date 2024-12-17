padre(luis, alicia).
padre(luis, josé). 
padre(jose, ana). 
madre(alicia, dario). 
abuelo(X, Y):-padre(X, Z), madre(Z, Y). 
abuelo(X, Y):-padre(X, Z), padre(Z, Y).



concatenar([], X, X). 
concatenar([X|Y], Z, [X|W]):- concatenar(Y, Z, W). 
member(X, [X|Y]). 
member(X, [Y|Z]):- member(X, Z). 