using Course.Domain.Interfaces;
using System;
using System.IO;
using System.Threading;

namespace Course.Domain.Entities
{
    public class Printer : Device, IPrinter
    {
        public Printer(string model)
        {
            Model = model;
        }

        public override void Process(Document doc)
        {
            Console.WriteLine($"Printer {Model} started processing the document...");

            Thread.Sleep(3333);

            Print(doc.FilePath, doc.Content);

            Console.WriteLine($"Printer {Model} finished processing the document!\n");
        }

        public void Print(string destinationPath, string documentContent)
        {
            File.WriteAllText(destinationPath, documentContent);
        }
    }
}
