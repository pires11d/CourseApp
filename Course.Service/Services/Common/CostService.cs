using System;

namespace Course.Service.Common
{
    public class CostService
    {
        public static double PricePerHour { get; set; }
        public static double PricePerDay { get; set; }
        public static double LimitingAmount { get; set; }
        public static double LimitingDuration { get; set; }
        public static double MinimumTaxPercent { get; set; }
        public static double MaximumTaxPercent { get; set; }

        public static double Tax(double amount)
        {
            if (amount <= LimitingAmount)
                return amount * MaximumTaxPercent;
            else
                return amount * MinimumTaxPercent;
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
