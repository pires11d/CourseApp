using Course.Entities.Exceptions;
using System;

namespace Course.Entities
{
    public class Account
    {
        private static int LastNumber { get; set; }
        public int Number { get; private set; }
        public string Holder { get; set; }
        public double Balance { get; set; }
        public double WithdrawLimit { get; set; }

        public Account(string holder)
        {
            Holder = holder;
            Balance = 0;
            WithdrawLimit = 1000.0;
            GenerateNumber();
        }

        public Account(string holder, double balance) : this(holder)
        {
            Balance = balance;
        }

        public Account(string holder, double balance, double withdrawLimit) : this(holder, balance)
        {
            WithdrawLimit = withdrawLimit;
        }

        public Account(int number, string holder, double balance, double withdrawLimit) : this(holder, balance, withdrawLimit)
        {
            Number = number;
        }

        private void GenerateNumber()
        {
            LastNumber += 1;
            Number = LastNumber;
        }

        public void Deposit(double amount)
        {
            Balance += amount;

            Console.WriteLine($"Operação de depósito realizada com sucesso!\n" +
                $"Saldo atual: {Balance:F2}");
        }

        public void Withdraw(double amount)
        {
            if (amount > WithdrawLimit)
            {
                throw new BusinessException("Limite de saque excedido!");
            }
            if (amount > Balance)
            {
                throw new BusinessException("Saldo insuficiente!");
            }

            Balance -= amount;
            Console.WriteLine($"Operação de saque realizada com sucesso!\n" +
                $"Saldo atual: {Balance:F2}");
        }

        public override string ToString()
        {
            return  $"Conta n°: \t {Number}\n" +
                    $"Titular: \t {Holder}\n" +
                    $"Saldo atual: \t {Balance.ToString("F2")} \n";
        }
    }
}
