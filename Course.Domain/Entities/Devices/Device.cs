namespace Course.Domain.Entities
{
    public abstract class Device
    {
        public string Model { get; set; }
        public abstract void Process(Document document);
    }
}
