%insertar(X,L,Y) triunfa si Y es el resultado de agregar X en alguna poscion de L
insertar(X,L,[X|L]).
insertar(X,[Y|L],[Y|R]):- insertar(X,L,R).

%permutation(X,Y) triunfa si Y es una permutacion de X
permutation([],[]);
permutation(L,[X|R]):- insertar(X,Y,L),permutation(Y,R).

%ordenar(X,Y) triunfa si Y es la lista de los elementos ordenados de X

ordenar(X,Y):- permutation(X,Y), ordenados(Y),!.


%ordenados(X) triunfa si X tiene los elementos ordenados

ordenados([]).
ordenados([_]).
ordenados([X,Y|Z]):- X=<Y , ordenados([Y|Z]).

%concatenar(X,Y,R) triunfa si R es la concatenacion de X con Y

concatenar([],Y,Y).
concatenar([X|T],Y,[X|R]):- concatenar(T,Y,R).

%aplanar(X,Y) triunfa si Y son lso elementos de X aplanados

aplanar([],[]).
aplanar([[]|Y],V):- !,aplanar(Y,V).
aplanar([[X|R]|Y],Z):- !, aplanar([X|R],U), aplanar(Y,V), concatenar(U,V,Z).
aplanar([X|Y],[X|Z]):- aplanar(Y,Z).

%minimo(X,Y,M) triunfa si M es el minimo entre X,Y

min(X,Y,X):- X=< Y,!.
min(X,Y,Y):- Y<X.

%disjuntas(L1,L2) triunfa si L1 y L2 son disjuntas

disjuntas(L1,L2):- not((member(X,L1), member(X,L2))).

%union(X,Y,Z) triunfa si Z es la union de X,y

union([],X,X).
union([X|Y],Z,[X|W]):- not(member(X,Z)), union(Y,Z,W).
union([X|Y],Z,W):- union(Y,Z,W).