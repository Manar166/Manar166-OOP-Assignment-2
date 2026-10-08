using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SrpLab.CheckoutBasket
{
    public class Payment
    {
        public string AuthorizePaymentStub(string cardLast4 ,CheckoutCalculator checkoutCalc,Checkout checkout)
        {
            
            // Pretends to talk to a gateway — auth scheme changes independently of cart rules.
            var payload = $"{checkoutCalc.GrandTotal():0.00}|{cardLast4}|{checkout.Lines.Count}";
            var hash = payload.GetHashCode();
            return $"AUTH-{Math.Abs(hash):X8}";
        }
    }
}
