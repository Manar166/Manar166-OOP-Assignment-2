using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.SubscribtionBillingClasses
{
    public class DunningEmailGenerator
    {
        private readonly SubscriptionBilling subscriptionBilling;
        private readonly InvoiceNumberGenerator invoiceNumberGenerator;
        private readonly ProrationCalculator prorationCalculator;

        public DunningEmailGenerator(SubscriptionBilling subscriptionBilling, InvoiceNumberGenerator invoiceNumberGenerator, 
            ProrationCalculator prorationCalculator)
        {
            this.subscriptionBilling = subscriptionBilling;
            this.invoiceNumberGenerator = invoiceNumberGenerator;
            this.prorationCalculator = prorationCalculator;
        }

        public string DunningEmail(string customerName, DateOnly asOf)
        {
            // Collections tone & legal boilerplate ≠ proration formula.
            var amount = prorationCalculator.Prorate(subscriptionBilling.PeriodStart);
            var invoice = invoiceNumberGenerator.NextInvoiceNumber(); // side-effect while composing mail — nasty on purpose
            var severity = subscriptionBilling.FailedPayments switch
            {
                <= 1 => "friendly reminder",
                2 => "second notice",
                _ => "final notice before suspension"
            };
            return $"Subject: {severity} {invoice}\nHi {customerName},\nBalance {amount:C} as of {asOf:o} ({subscriptionBilling.FailedPayments} failures).\n";
        }
    }
}
