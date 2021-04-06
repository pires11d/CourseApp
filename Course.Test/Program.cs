using Course.Entities;
using Course.Service;
using System;
using System.Globalization;
using System.Text;

namespace Course
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Start("Rental");
        }

        private static void Start(string serviceName)
        {
            Extensions.CallByName(serviceName);
        }

        public void Rental()
        {
            new RentalService().Start();
        }

        public void Account()
        {
            new AccountService().Start();     
        }

        private void Person()
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

        private void Types()
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
