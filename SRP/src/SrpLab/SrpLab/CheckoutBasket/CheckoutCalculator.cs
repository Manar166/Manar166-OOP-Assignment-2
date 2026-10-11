using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.CheckoutBasket
{
    public class CheckoutCalculator
    {
       
        CouponDiscountCalculator _couponCalculator;
        Gift _gift;
        public CheckoutCalculator(Gift gift)
        {
           
            _gift = gift;
        }
        public decimal GrandTotal( decimal subTotal,decimal DiscountAmount)
        {
            var total = subTotal - DiscountAmount;
            if (_gift.GiftWrap) total += 4.99m; // packaging fee policy ≠ cart math
            return Math.Max(0m, total);
        }
    }
}
