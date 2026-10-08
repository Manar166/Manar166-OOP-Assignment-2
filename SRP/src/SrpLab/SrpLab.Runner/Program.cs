
using SrpLab.CheckoutBasket;

namespace SrpLab.Runner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SrpLab — 10 intentional SRP violations (refactor me)");
            Console.WriteLine("=================================================");


          
            HandoffNoteBuilder handoffBuilder = new HandoffNoteBuilder();
            var pagerService = new PagerService();
            var acuityCalculator = new AcuityCalculator();
            var ward = new WardBoard(pagerService, acuityCalculator);

            ward.AssignBed(1, "p-88", heartRate: 130, spo2: 89);
            Console.WriteLine(handoffBuilder.BuildHandoffNote(1, ward));
            Console.WriteLine(string.Join(" | ", pagerService.DrainPagerLog()));


            CouponDiscountCalculator couponCalculator = new CouponDiscountCalculator();
            Gift gift = new Gift();
            var basket = new Checkout();
            CheckoutCalculator checkoutCalculator = new CheckoutCalculator(basket, couponCalculator, gift);

            var payment = new Payment();
            basket.AddLine("SKU-1", 40m, 2);
            couponCalculator.ApplyCouponText("SAVE10");
            gift.EnableGiftWrap();
            Console.WriteLine($"basket total={checkoutCalculator.GrandTotal()} auth={payment.AuthorizePaymentStub("4242", checkoutCalculator, basket)}");

        }
    }
}
