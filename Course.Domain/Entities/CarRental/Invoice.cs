namespace Course.Domain.Entities
{
    public class Invoice
    {
        public double BaseCost { get; set; }
        public double Tax { get; set; }

        public Invoice(double baseCost, double tax)
        {
            BaseCost = baseCost;
            Tax = tax;
        }

        public double TotalCost
        {
            get { return BaseCost + Tax; }
        }

        public override string ToString()
        {
            return  $"Subtotal: {BaseCost.ToString("F2")}\n" +
                    $"Taxa: {Tax.ToString("F2")}\n" +
                    $"TOTAL: {TotalCost.ToString("F2")}";
        }
    }
}
