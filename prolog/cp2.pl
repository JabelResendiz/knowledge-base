% Concatenar dos listas
concatenar([],X,X).
concatenar([X|R],Y,[X|Z]):- concatenar(R,Y,Z).

% Verificar que un elemento es miembro de una lista
member(X,[X|_]).
member(X,[_|L2]):- member(X,L2).

% Verificar que un elemento no es miembro de una lista
not_member(_,[]).
not_member(X,[Z|Y]):- X \= Z, not_member(X,Y).

% Intersección de dos listas
interseccion([], _, []).
interseccion([X|L1], L2, [X|I]):- member(X, L2), interseccion(L1, L2, I).
interseccion([X|L1], L2, I):- not_member(X, L2), interseccion(L1, L2, I).

eliminar(_,[],[]).
eliminar(X,[X|L1],L2):- eliminar(X,L1,L2).
eliminar(X,[Y|L1],[Y|L2]):- X\=Y, eliminar(X,L1,L2).

son_iguales([],[]).
son_iguales([X|P],L):- member(X,L),eliminar(X,L,I),son_iguales(I,P).

