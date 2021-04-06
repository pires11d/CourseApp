using System;

namespace Course.Service
{
    public class CostService
    {
        public static double PricePerHour { get; set; }
        public static double PricePerDay { get; set; }

        public static double Tax(double amount)
        {
            if (amount <= 100.0)
                return amount * 0.2;
            else
                return amount * 0.15;
        }

        public static double BaseCost(TimeSpan duration)
        {
            if (duration.TotalHours <= 12.0)
                return PricePerHour * Math.Ceiling(duration.TotalHours);
            else
                return PricePerDay * Math.Ceiling(duration.TotalDays);
        }
    }
}
