using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.CheckoutBasket
{
    public class Gift
    {
        public bool GiftWrap { get; private set; }
        public Checkout checkoutBasket { get; }

        public CheckoutCalculator CheckoutCalculator { get; }
        public string GiftMessageCard(string fromName)
        {
            // Customer-facing copy will change with marketing, not with totals.
            var items = string.Join(", ", checkoutBasket.Lines.Select(l => l.Sku));
            return $"Dear friend,\nA gift from {fromName} awaits ({items}).\nTotal surprise value: {CheckoutCalculator.GrandTotal():C}\n";
        }

        public void EnableGiftWrap() => GiftWrap = true;
    }
}
