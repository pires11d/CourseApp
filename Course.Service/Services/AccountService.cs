using Course.Entities;
using Course.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Course.Services
{
    public class AccountService
    {
        public AccountService()
        {
            Accounts = new List<Account>();
        }
        public List<Account> Accounts { get; set; }

        public void StartOperation()
        {
            // CRIAÇÃO DE CONTA
            Console.Clear();
            Console.WriteLine("NOVA OPERAÇÃO");
            Console.WriteLine("-----------------------------------------------------------");
            Console.Write("Informe o nome do titular: ");
            string name = Console.ReadLine();
            double amount = 0.0;
            Console.Write("Informe o saldo inicial da conta: ");
            try
            {
                amount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Erro no valor de entrada: {ex.Message}");
                Console.ReadLine();
                StartOperation();
            }

            Account conta = new Account(name, amount);
            Console.WriteLine(conta);
            Accounts.Add(conta);

            // OPERAÇÕES COM A CONTA
            try
            {
                Console.Write("Deseja alterar o limite de saque? (S/N) ");
                var answer = Console.ReadKey();
                Console.WriteLine();
                if (answer.Key == ConsoleKey.S)
                {
                    Console.Write("Informe um valor para ser o novo limite de saque: ");
                    double limitAmount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    conta.WithdrawLimit = limitAmount;
                }

                Console.Write("Informe uma quantia para depósito: ");
                double depositAmount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                conta.Deposit(depositAmount);
                Console.WriteLine(conta);

                Console.Write("Informe uma quantia para saque: ");
                double withdrawalAmount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                conta.Withdraw(withdrawalAmount);
                Console.WriteLine(conta);
            }
            catch (BusinessException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Erro no valor de entrada: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // INÍCIO DE UM NOVO CICLO
            var option = Console.ReadKey();
            switch (option.Key)
            {
                case ConsoleKey.Enter:
                    StartOperation();
                    break;
                case ConsoleKey.Escape:
                    break;
                default:
                    break;
            }
        }
    }
}
