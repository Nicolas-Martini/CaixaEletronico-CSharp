using System;
using System.Globalization;

namespace Exercicio
{
    internal class Program
    {
        static void ExibirMenu()
        {
            Console.WriteLine("==== CAIXA ELETRÔNICO ====");
            Console.WriteLine("1 - Consultar saldo");
            Console.WriteLine("2 - Depositar dinheiro");
            Console.WriteLine("3 - Sacar dinheiro");
            Console.WriteLine("4 - Ver histórico");
            Console.WriteLine("5 - Sair");
        }

        static void Main(string[] args)
        {
            ContaBancaria conta = new ContaBancaria("Nicolas", 1000m);

            bool executando = true;

            while (executando)
            {
                ExibirMenu();

                Console.Write("Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out int opcao))
                {
                    Console.WriteLine("Digite uma opção válida!");
                    Console.WriteLine();
                    continue;
                }

                Console.WriteLine();

                switch (opcao)
                {
                    case 1:
                        conta.ConsultarSaldo();
                        break;

                    case 2:
                        Console.Write("Valor do depósito: ");

                        if (!decimal.TryParse(
                            Console.ReadLine(),
                            NumberStyles.Number,
                            CultureInfo.CurrentCulture,
                            out decimal deposito))
                        {
                            Console.WriteLine("Digite um número válido!");
                        }
                        else
                        {
                            conta.Depositar(deposito);
                        }

                        break;

                    case 3:
                        Console.Write("Valor que deseja sacar: ");

                        if (!decimal.TryParse(
                            Console.ReadLine(),
                            NumberStyles.Number,
                            CultureInfo.CurrentCulture,
                            out decimal saque))
                        {
                            Console.WriteLine("Digite um número válido!");
                        }
                        else
                        {
                            conta.Sacar(saque);
                        }

                        break;

                    case 4:
                        conta.ExibirHistorico();
                        break;

                    case 5:
                        Console.WriteLine("Saindo...");
                        executando = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida... Tente novamente.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
