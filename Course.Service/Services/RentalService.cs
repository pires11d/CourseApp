using Course.Domain.Entities;
using Course.Service.Common;
using System;
using System.Globalization;

namespace Course.Service.Services
{
    public class RentalService : IService
    {
        public RentalService()
        {
            CostService.LimitingAmount = 100;
            CostService.MinimumTaxPercent = 0.15;
            CostService.MaximumTaxPercent = 0.20;
        }

        public Rental Rental { get; set; }

        public void Start()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("NOVO ALUGUEL:\n");

                Console.Write("Entre com o modelo do carro: ");
                string model = Console.ReadLine();

                Console.Write("Data inicial do aluguel (dd/MM/yyyy HH:mm): ");
                DateTime beginDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                Console.Write("Data final do aluguel (dd/MM/yyyy HH:mm): ");
                DateTime endDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                Console.Write("Entre com o valor do preço/hora: ");
                CostService.PricePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Entre com o valor do preço/dia: ");
                CostService.PricePerDay = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Rental = new Rental(beginDate, endDate, new Vehicle(model));

                ProcessInvoice();

                Console.WriteLine("FATURA: \n");

                Console.WriteLine(Rental.Invoice);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();

            Start();
        }

        private void ProcessInvoice()
        {
            double baseCost = CostService.BaseCost(Rental.Duration);
            double tax = CostService.Tax(baseCost);
            Rental.Invoice = new Invoice(baseCost, tax);
        }
    }
}
