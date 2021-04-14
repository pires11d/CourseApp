using Course.Entities;
using Course.Service;
using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Course
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Start();
        }

        private static void Start()
        {
            ShowHelp();
            var input = Console.ReadLine();
            StartService(input);
        }

        private static void ShowHelp()
        {
            var servicesList = ServiceManager.GetServices();
            servicesList = servicesList.Select(x => { x = " - " + x; return x; }).ToList();
            string services = String.Join("\n", servicesList);
            string help = "Escolha o serviço que deseja iniciar:\n" + services;

            Console.WriteLine(help);
        }

        private static void StartService(string serviceName)
        {
            try
            {
                IService service = ServiceManager.GetByName(serviceName);
                Console.Clear();
                service.Start();
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                Console.WriteLine("Digite qualquer tecla para continuar...");
                Console.ReadLine();
            }
            finally
            {
                Console.ReadLine();
                Console.Clear();
                Start();
            }
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


    public class Helper
    {
        /// <summary>
        /// Rotina capaz de chamar qualquer método presente no escopo desta classe pelo nome (via <see cref="string"/>)
        /// </summary>
        public static void CallByName(string methodName, string param = null)
        {
            var program = new Program();
            Type type = program.GetType();
            MethodInfo methodInfo = type.GetMethod(methodName);
            if (methodInfo != null)
            {
                if (param != null)
                    methodInfo.Invoke(program, new object[] { param });
                else
                    methodInfo.Invoke(program, new object[] { });
            }
            else
            {
                Console.WriteLine("Método não encontrado!");
            }
        }


    }
}
