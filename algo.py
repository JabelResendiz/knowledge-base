

elems = [100,50,75,25,150]

def MinMax(a):
    min = a[0]
    max = a[0]

    for i in range(1,len(a)):
        if(a[i] <min): min = a[i]
        elif (a[i] > max): max = a[i]
    
    return (min,max)

result1 = MinMax(elems)

result2 = result1

m,n = result2

n = 555

print(result1)
print(f"{result2[0]}, {result2[1]}")
#print(f"{result1.min}, {result1.max}") # se produce un execpcion aqui