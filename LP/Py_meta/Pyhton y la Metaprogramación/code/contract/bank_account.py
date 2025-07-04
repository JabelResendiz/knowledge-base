# Importamos el decorador que creamos antes
from contract_decorator import contract

class CuentaBancaria:

    @contract(require=lambda self, saldo_inicial: saldo_inicial >= 0)
    def __init__(self, saldo_inicial):
        self.saldo = saldo_inicial

    @contract(require=lambda self, monto: monto > 0, ensure=lambda result: result >= 0)
    def depositar(self, monto):
        self.saldo += monto
        return self.saldo

    @contract(require=lambda self, monto: monto > 0, ensure=lambda result: result >= 0)
    def retirar(self, monto):
        self.saldo -= monto
        return self.saldo

    def obtener_saldo(self):
        return self.saldo


# 🚀 Ejecución
cuenta = CuentaBancaria(1000)
print(f"Saldo inicial: {cuenta.obtener_saldo()}")  # Saldo inicial: 1000
cuenta.depositar(500)
print(f"Saldo después del depósito: {cuenta.obtener_saldo()}")  # Saldo después del depósito: 1500
cuenta.retirar(2000)
print(f"Saldo después del retiro: {cuenta.obtener_saldo()}")  # Saldo después del retiro: 1200

print(f"Saldo final: {cuenta.obtener_saldo()}")  # Saldo final: 1200