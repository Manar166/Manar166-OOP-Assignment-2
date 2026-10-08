using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.CheckoutBasket
{
    public class Checkout
    {
        //public Checkout(Gift gift, CouponDiscountCalculator couponCalculator)
        //{
        //    Gift = gift;
        //    CouponCalculator = couponCalculator;
        //}

        public  List<(string Sku, decimal Price, int Qty)> Lines { get; } = new();
        public Gift Gift { get; }
        public decimal SubTotal() => Lines.Sum(l => l.Price * l.Qty);

        public CouponDiscountCalculator CouponCalculator { get; } = new();
       

        public void AddLine(string sku, decimal price, int qty)
        {
            if (qty <= 0) throw new ArgumentOutOfRangeException(nameof(qty));
            Lines.Add((sku, price, qty));
        }


      

     

       

       

        
      
    }
}
