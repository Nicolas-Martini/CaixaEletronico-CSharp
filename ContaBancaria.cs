using System;
using System.Collections.Generic;
using System.Globalization;

namespace Exercicio
{
    internal class ContaBancaria
    {
        public decimal Saldo { get; private set; }

        public string Titular { get; private set; }

        private List<string> historico = new List<string>();

        public ContaBancaria(string titular, decimal saldoInicial)
        {
            if (string.IsNullOrWhiteSpace(titular))
            {
                Titular = "Titular não informado";
            }
            else
            {
                Titular = titular;
            }

            if (saldoInicial < 0)
            {
                Saldo = 0;
                Console.WriteLine("Saldo inicial inválido!");
            }
            else
            {
                Saldo = saldoInicial;
            }
        }

        public void ConsultarSaldo()
        {
            Console.WriteLine($"Titular: {Titular}");
            Console.WriteLine($"Saldo: {Saldo.ToString("C2", CultureInfo.CurrentCulture)}");
        }

        public void Depositar(decimal valor)
        {
            if (valor <= 0)
            {
                Console.WriteLine("Valor inválido!");
            }
            else
            {
                Saldo += valor;

                historico.Add(
                    $"{DateTime.Now:dd/MM/yyyy HH:mm:ss} | Depósito: {valor:C2} | Saldo: {Saldo:C2}"
                );

                Console.WriteLine("Depósito realizado com sucesso!");
            }
        }

        public void Sacar(decimal valor)
        {
            if (valor <= 0)
            {
                Console.WriteLine("Valor inválido!");
            }
            else if (valor > Saldo)
            {
                Console.WriteLine("Saldo insuficiente!");
            }
            else
            {
                Saldo -= valor;

                historico.Add(
                    $"{DateTime.Now:dd/MM/yyyy HH:mm:ss} | Saque: {valor:C2} | Saldo: {Saldo:C2}"
                );

                Console.WriteLine("Saque realizado com sucesso!");
            }
        }

        public void ExibirHistorico()
        {
            Console.WriteLine("==== HISTÓRICO BANCÁRIO ====");
            Console.WriteLine();

            if (historico.Count == 0)
            {
                Console.WriteLine("Nenhuma operação realizada.");
                return;
            }

            foreach (string operacao in historico)
            {
                Console.WriteLine(operacao);
            }

            Console.WriteLine();
            Console.WriteLine($"Total de operações: {historico.Count}");
        }
    }
}
