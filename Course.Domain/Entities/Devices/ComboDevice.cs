using Course.Domain.Interfaces;

namespace Course.Domain.Entities
{
    public class ComboDevice : Device, IScanner, IPrinter
    {
        public override void Process(Document doc)
        {
            throw new System.NotImplementedException();
        }

        public void Print(string path, string content)
        {
            throw new System.NotImplementedException();
        }

        public string Scan(string path)
        {
            throw new System.NotImplementedException();
        }
    }
}
