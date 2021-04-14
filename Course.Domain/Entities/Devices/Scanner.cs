using Course.Domain.Interfaces;
using System;
using System.IO;
using System.Threading;

namespace Course.Domain.Entities
{
    public class Scanner : Device, IScanner
    {
        public Scanner(string model)
        {
            Model = model;
        }

        public override void Process(Document doc)
        {
            Console.WriteLine($"Scanner {Model} started scanning the document...");

            Thread.Sleep(3333);

            doc.Content = Scan(doc.FilePath);

            Console.WriteLine($"Scanner {Model} finished scanning the document!\n");

            Console.WriteLine(doc.Content);
        }

        public string Scan(string sourcePath)
        {
            string content = File.ReadAllText(sourcePath);

            return content.Trim();
        }
    }
}
