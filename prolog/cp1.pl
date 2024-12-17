
divide([],[],[]).
divide([X], [X],[]).
divide([X,Y|Z],[X|I],[Y|P]):- divide(Z,I,P).




consecutivos(X,Y,[X,Y|R]).
consecutivos(X,Y,[_|R]):- consecutivos(X,Y,R).


add(X,[],[X]).
add(X,[Y|Z],[Y|R]):-add(X,Z,R).

reverso([],[]).
reverso([X|Y],R):- reverso(Y,A), add(X,A,R).

palindromo([]).
palindromo([X]).
palindromo([X|R]):- palindromo(L),add(X,L,R).