using Course.Domain.Entities;
using System.IO;

namespace Course.Service.Services
{
    public class DeviceService : IService
    {
        public string CurrentPath = Path.Join(Directory.GetCurrentDirectory(), "teste.txt");
        public string CurrentContent = "\n\n\n\t\t\tOlá pessoal, tudo certinho?\n Vou fazer uma pergunta meia séria...\n\n\n\t\t\t";

        public void Start()
        {
            var printer = new Printer("DCP-1000");
            var scanner = new Scanner("DS-640");
            var document = new Document { Content = CurrentContent, FilePath = CurrentPath };

            printer.Process(document);

            scanner.Process(document);
        }
    }
}
