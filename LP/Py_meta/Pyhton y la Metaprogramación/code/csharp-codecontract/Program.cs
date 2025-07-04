using System;
using System.Diagnostics.Contracts;

public class CuentaBancaria
{
    public decimal Saldo { get; private set; }

    public CuentaBancaria(decimal saldoInicial)
    {   
        Contract.Requires(saldoInicial >= 0, "El saldo inicial no puede ser negativo.");
        Saldo = saldoInicial;
    }

    public void Depositar(decimal monto)
    {
        Contract.Requires(monto > 0, "El monto debe ser positivo.");
        Contract.Ensures(Saldo >= Contract.OldValue(Saldo), "El saldo debe aumentar después del depósito.");

        Saldo += monto;
    }

    public void Retirar(decimal monto)
    {
        Contract.Requires(monto > 0, "El monto debe ser positivo.");
        Contract.Requires(Saldo >= monto, "No puede retirar más de lo que tiene.");
        Contract.Ensures(Saldo == Contract.OldValue(Saldo) - monto, "El saldo debe reducirse después del retiro.");

        Saldo -= monto;
    }
}

class Program
{
    static void Main()
    {
        // Manejador para imprimir errores de contrato en consola
        Contract.ContractFailed += (sender, e) =>
        {
            Console.WriteLine($"Error de contrato: {e.Message}");
            // Lanzar excepción cuando no se cumpla el contrato
            throw new Exception($"Contrato no cumplido: {e.Message}");
        };

        CuentaBancaria cuenta = new CuentaBancaria(1000);
        cuenta.Depositar(500);
        cuenta.Retirar(10000);
        Console.WriteLine($"Saldo final: {cuenta.Saldo}");
    }
}