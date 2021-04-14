using Course.Domain.Entities;

namespace Course.Domain.Interfaces
{
    public interface IScanner
    {
        public string Scan(string path);
    }
}
