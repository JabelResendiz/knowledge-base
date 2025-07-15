import random

def BoolGenerator():
  return random.choice([False, True])
v = 0
i = 0
while True:
  i += 1
  if BoolGenerator():
    v=v+1
  else:
    v=v+"ABC"   # error no se puede hacer suma entre int y str
  print(f"{i} {v+10}")
  input()

