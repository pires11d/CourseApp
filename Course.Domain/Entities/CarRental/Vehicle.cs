namespace Course.Domain.Entities
{
    public class Vehicle
    {
        public string Model { get; set; }

        public Vehicle(string model)
        {
            Model = model;
        }
    }
}
