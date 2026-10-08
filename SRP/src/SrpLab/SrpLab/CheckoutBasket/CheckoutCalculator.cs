using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.CheckoutBasket
{
    public class CheckoutCalculator
    {
        Checkout _checkout;
        CouponDiscountCalculator _couponCalculator;
        Gift _gift;
        public CheckoutCalculator(Checkout checkout, CouponDiscountCalculator couponCalculator, Gift gift)
        {
            _checkout = checkout;
            _couponCalculator = couponCalculator;
            _gift = gift;
        }
        public decimal GrandTotal()
        {
            var total = _checkout.SubTotal() - _couponCalculator.DiscountAmount(_checkout);
            if (_gift.GiftWrap) total += 4.99m; // packaging fee policy ≠ cart math
            return Math.Max(0m, total);
        }
    }
}
