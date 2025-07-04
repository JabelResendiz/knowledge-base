class SingletonMeta(type):
    """Metaclase para el patrón Singleton. Asegura una única instancia por clase."""
    _instances = {}

    def __call__(cls, *args, **kwargs):
        if cls not in cls._instances:
            instance = super().__call__(*args, **kwargs)
            cls._instances[cls] = instance
        return cls._instances[cls]

class Singleton(metaclass=SingletonMeta):
    """Clase base para el patrón Singleton"""
    pass

class ObjetoInmutableMeta(type):
    def __new__(cls, name, bases, attrs):
        def bloqueador(self, *args, **kwargs):
            raise AttributeError("Objeto inmutable")
        attrs["__setattr__"] = bloqueador
        attrs["__delattr__"] = bloqueador
        return super().__new__(cls, name, bases, attrs)

class ObjetoInmutable(metaclass=ObjetoInmutableMeta):
    """Clase base para Objeto Inmutable"""
    pass

