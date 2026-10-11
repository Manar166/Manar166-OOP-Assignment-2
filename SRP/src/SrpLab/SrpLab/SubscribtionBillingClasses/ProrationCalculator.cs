using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.SubscribtionBillingClasses
{
    public class ProrationCalculator
    {
        private readonly SubscriptionBilling subscriptionBilling;

        public ProrationCalculator(SubscriptionBilling subscriptionBilling)
        {
            this.subscriptionBilling = subscriptionBilling;
        }

        public decimal Prorate(DateOnly activeFrom)
        {
            // Finance calendar rules change independently of email copy.
            if (activeFrom <= subscriptionBilling.PeriodStart) return subscriptionBilling.MonthlyPrice;
            if (activeFrom >= subscriptionBilling.PeriodEnd) return 0m;
            var totalDays = subscriptionBilling.PeriodEnd.DayNumber - subscriptionBilling.PeriodStart.DayNumber;
            if (totalDays <= 0) return subscriptionBilling.MonthlyPrice;
            var used = subscriptionBilling.PeriodEnd.DayNumber - activeFrom.DayNumber;
            return Math.Round(subscriptionBilling.MonthlyPrice * used / totalDays, 2);
        }
    }
}
