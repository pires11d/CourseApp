using System;

namespace Course.Domain.Entities
{
    public class Rental
    {
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public Vehicle Vehicle { get; set; }
        public Invoice Invoice { get; set; }

        public Rental(DateTime startDate, DateTime finishDate, Vehicle vehicle)
        {
            BeginDate = startDate;
            EndDate = finishDate;
            Vehicle = vehicle;
        }

        public TimeSpan Duration
        {
            get { return EndDate.Subtract(BeginDate); }
        }
    }
}
