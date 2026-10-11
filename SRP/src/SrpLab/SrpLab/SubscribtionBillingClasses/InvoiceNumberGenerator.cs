using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.SubscribtionBillingClasses
{
    public class InvoiceNumberGenerator
    {
        private static int _invoiceSeq = 1000;
        private readonly SubscriptionBilling subscriptionBilling;

        public InvoiceNumberGenerator(SubscriptionBilling subscriptionBilling)
        {
            this.subscriptionBilling = subscriptionBilling;
        }

        public string NextInvoiceNumber()
        {
            // Numbering scheme / fiscal prefixes — ops concern, not pricing.
            var n = ++_invoiceSeq;
            return $"INV-{subscriptionBilling.PeriodStart:yyyyMM}-{n:D5}";
        }
    }
}
