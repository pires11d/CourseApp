using Course.Entities;
using Course.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace Course
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Extensions.CallByName("TestingAccount");
        }       

        public static void TestingAccount()
        {
            List<Account> contas = new List<Account>();
            StartAccountOperation(contas);            
        }

        private static void StartAccountOperation(List<Account> contas)
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
                StartAccountOperation(contas);
            }

            Account conta = new Account(name, amount);
            Console.WriteLine(conta);
            contas.Add(conta);

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
                    StartAccountOperation(contas);
                    break;
                case ConsoleKey.Escape:
                    break;
                default:
                    break;
            }
        }

        private static void TestingPerson()
        {
            string nome = "Maria";
            char genero = 'F';
            int idade = 27;
            double altura = 1.70;

            var pessoa = new Person(nome, idade, altura, genero);

            Console.WriteLine(pessoa.ToString(1));
            Console.WriteLine(pessoa.ToString(2));
            Console.WriteLine(pessoa.ToString(3));
        }

        private static void TestingTypes()
        {
            sbyte sb = 127;
            (short s1, short s2) = (-32767, 32767);
            (int i1, int i2) = (int.MinValue, int.MaxValue);
            (long l1, long l2) = (long.MinValue, long.MaxValue);
            long L = 2147483648L;
            float F = 4.5F;
            double D = 4.5D;
            decimal dec = Decimal.Parse("3.333");


            Console.WriteLine(sb);
            Console.WriteLine(s1 + "," + s2);
            Console.WriteLine(i1 + "," + i2);
            Console.WriteLine(l1 + "," + l2);
            Console.WriteLine(L);
            Console.WriteLine(F);
            Console.WriteLine(D);
            Console.WriteLine(dec);
            Console.WriteLine(dec.ToString("F2"));
            Console.WriteLine(dec.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
