
mcd(X,0,X).
mcd(X,Y,Z):- W is X mod Y, mcd(Y,W,Z).

fact(0,1).
fact(N,F):- Z is N-1, fact(Z,X), F is X*N.

pot(X,0,1).
pot(X,N,P):- Z is N-1, pot(X,Z,Y), P is Y*X.

sumalista([],0).
sumalista([X|Y],R):- sumalista(Y,L), R is L+X.

cantidad([],0).
cantidad([X|Y],C):- cantidad(Y,L), C is L+1.

producto_escalar([],[],0).
producto_escalar([X|Y],[Z|W],P):- C is X*Z, producto_escalar(Y,W,S), P is C+S.

producto_vectorial([X1,X2,X3],[Y1,Y2,Y3],[Z1,Z2,Z3]):- Z3 is X1*Y2 - Y1*X2,
                                                       Y3 is Z1*X2 - X1*Z2,
                                                       X3 is Y1*Z2 - Z1*Y2.

%u(L,C) triunfa si C son los elementos distintos de L
u([],[]).
u([X|T],R):- member(X,T),u(T,R).
u([X|T],[X|R]):- not(member(X,T)),u(T,R).

%mayor(L,X) triunfa si X es un elemento de L


max(X,Y,X):- X>Y,!.
max(X,Y,Y):- X=<Y.


mayor([X],X).
mayor([X|R],T):- mayor(R,Z), max(Z,X,T).

%eliminar(X,L,R) triunfa si R es el resultado de eliminar todas las ocurrecnias de X en L

eliminar(X,[],[]).
eliminar(X,[X|R],T):-eliminar(X,R,T),!.
eliminar(X,[Y|R],[Y|G]):- eliminar(X,R,G),!.

%mayor2(L,X) triunfa si X es el segundo mayor elemento de L

mayor2(L,X):- mayor(L,Y), eliminar(Y,L,R), mayor(R,X). 