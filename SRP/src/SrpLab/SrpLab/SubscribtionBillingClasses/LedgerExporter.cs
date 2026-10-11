using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.SubscribtionBillingClasses
{
    public class LedgerExporter
    {
        private readonly SubscriptionBilling subscriptionBilling;
        private readonly InvoiceNumberGenerator invoiceNumberGenerator;
        private readonly ProrationCalculator prorationCalculator;

        public LedgerExporter(SubscriptionBilling subscriptionBilling, InvoiceNumberGenerator invoiceNumberGenerator,
            ProrationCalculator prorationCalculator)
        {
            this.subscriptionBilling = subscriptionBilling;
            this.invoiceNumberGenerator = invoiceNumberGenerator;
            this.prorationCalculator = prorationCalculator;
        }
        public string LedgerJournalLine(DateOnly activeFrom)
        {
            // Accounting export format is another axis of change.
            return $"{subscriptionBilling.CustomerId},{invoiceNumberGenerator.NextInvoiceNumber()},{prorationCalculator.Prorate(activeFrom):0.00},AR-SUB";
        }
    }
}
