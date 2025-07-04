from patrones_metaclases import Singleton, ObjetoInmutable

# Ejemplo de Singleton
class Logger(Singleton):
    def __init__(self):
        self.log = []

    def write(self, message):
        self.log.append(message)

# Demostración del Singleton
logger1 = Logger()
logger2 = Logger()
logger1.write("Mensaje 1")
logger2.write("Mensaje 2")
print("Logger es singleton:", logger1 is logger2)  # True
print("Log compartido:", logger1.log)  # ['Mensaje 1', 'Mensaje 2']

# Ejemplo de ObjetoInmutable
class Punto(ObjetoInmutable):
    def __init__(self, x, y):
        self.x = x
        self.y = y

# Demostración de ObjetoInmutable
p = Punto(1, 2)
print(f"Punto: x={p.x}, y={p.y}")
try:
    p.x = 10
except AttributeError as e:
    print("Error al modificar atributo:", e)
try:
    del p.y
except AttributeError as e:
    print("Error al eliminar atributo:", e)
