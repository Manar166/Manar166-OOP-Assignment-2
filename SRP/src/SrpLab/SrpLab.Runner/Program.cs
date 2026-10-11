
using SrpLab.AppointmentDeskClasses;
using SrpLab.CheckoutBasket;
using SrpLab.CourseEnrollmentClasses;
using SrpLab.GradeBookClasses;
using SrpLab.KitchenClasses;
using SrpLab.LoanDeskClasses;
using SrpLab.SubscribtionBillingClasses;
using SrpLab.SupportTicket;
using SrpLab.WardBoardClasses;
using SrpLab.WarehousePickListClasses;

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

            Console.WriteLine("=================================================");





            var basket = new Checkout();
            basket.AddLine("SKU-1", 40m, 2);

            CouponDiscountCalculator couponCalculator = new CouponDiscountCalculator();
            couponCalculator.ApplyCouponText("SAVE10");

            decimal subTotal = basket.SubTotal();
            decimal discount = couponCalculator.DiscountAmount(subTotal);
            Gift gift = new Gift();
           
            CheckoutCalculator checkoutCalculator = new CheckoutCalculator(gift);

            var payment = new Payment();
          
            gift.EnableGiftWrap();
            var grandTotal = checkoutCalculator.GrandTotal(subTotal, discount);
            Console.WriteLine($"basket total={grandTotal} auth={payment.AuthorizePaymentStub("4242", grandTotal, basket)}");

            Console.WriteLine("=================================================");
            //support Ticket 


            PriorityCalculate priorityCalculate = new PriorityCalculate();
            var ticket = new Ticket("T-1", "cannot login", "prod is down for me", DateTimeOffset.UtcNow, priorityCalculate);


            string priorty = priorityCalculate.RecalculatePriorityFromText("cannot login", "prod is down for me");

            SlaCalculator slaCalculator = new SlaCalculator();

            DateTimeOffset deadLine = slaCalculator.SlaDeadline(priorty, DateTimeOffset.UtcNow);

            PublicReplyBuilder publicReply = new PublicReplyBuilder();
            Console.WriteLine(publicReply.DraftPublicReply("T-1", priorty,"Nora", deadLine));



            Console.WriteLine("=================================================");
            //Loan Desk

            var loan = new LoanDesk(60_000m, 640, 4, hasCollateral: false);
            var LoanRiskEvaluator = new LoanRiskEvaluator(loan);
            var requiredDocs = new DocumentRequiredProvider(loan, LoanRiskEvaluator);
            var loanDesicionLetter = new LoanDecisionLetterGenerator(LoanRiskEvaluator, loan, requiredDocs);
            Console.WriteLine(loanDesicionLetter.DecisionLetter("Omar"));
            Console.WriteLine("=================================================");
            //CourseEnrollement
            var course = new Course("SEF-101", capacity: 1, tuition: 3000m);
            var CourseEnrollment = new EnrollmentManger(course);
            Console.WriteLine(CourseEnrollment.Register("a@mail.com"));
            Console.WriteLine( CourseEnrollment.Register("b@mail.com"));
            var welcomePacketGen = new WelcomePacketGenerator(course, CourseEnrollment);
            Console.WriteLine(welcomePacketGen.WelcomePacketMarkdown("b@mail.com", "Bea"));
            Console.WriteLine("=================================================");
            // Kitchen 

            var kitchen = new KitchenTicket();
            kitchen.AddItem("Pasta", new[] { "wheat", "milk" }, 12);

            AllergensDetector allergensDetector = new AllergensDetector(kitchen);
            KitchenEtaEstimator kitchenEtaEstimator = new KitchenEtaEstimator(kitchen, allergensDetector);

            ThermalTicketRenderer thermalTicketRenderer = new ThermalTicketRenderer(kitchen, allergensDetector, kitchenEtaEstimator);
            Console.WriteLine(thermalTicketRenderer.RenderThermalTicket(42));
            Console.WriteLine("=================================================");
            //SubscribtionBilling
            var sub = new SubscriptionBilling("c-9", 99m, new DateOnly(2026, 9, 1), new DateOnly(2026, 10, 1));
            sub.RegisterFailedPayment();

            InvoiceNumberGenerator invoiceNumberGenerator = new InvoiceNumberGenerator(sub);
            var proirationCalc = new ProrationCalculator(sub);

            DunningEmailGenerator dunningEmailGenerator = new DunningEmailGenerator(sub, invoiceNumberGenerator, proirationCalc);

            Console.WriteLine(dunningEmailGenerator.DunningEmail("Sara", new DateOnly(2026, 9, 20)));
            Console.WriteLine("=================================================");
            // WareHouse

            var pick = new WarehousePickList();
            pick.AddNeed("BOLT", "A", 3, 10, 7);
            pick.AddNeed("NUT", "B", 1, 5, 5);

            StockAllocator stockAllocator = new StockAllocator(pick);
            var planner = new PickingRoutePlanner(pick);
            PickerScriptGenerator pickerScriptGenerator = new PickerScriptGenerator(pick,stockAllocator,planner);
            Console.WriteLine(pickerScriptGenerator.PickerScript());

            Console.WriteLine("=================================================");
            //GradeBook
            var grades = new GradeBook();
            grades.Record("s1", 92);
            grades.Record("s1", 88);
            var avg1 = grades.Average("s1");
            var avg2 = grades.Average("s2");
            var gradePolicy = new GradePolicy();
            string letter= gradePolicy.Letter(avg1);
            bool isHonor = new HonorRollEvaluator(gradePolicy).MeetsHonorRoll(avg1);
            TranscriptGenerator generator = new TranscriptGenerator();
            Console.WriteLine(generator.TranscriptPlain("s1", "Ali",avg1,letter,isHonor));
            Console.WriteLine("=================================================");
            //AppointmentDesk

            var appt = new AppointmentDesk(new TimeOnly(9, 0), new TimeOnly(17, 0), 30);
            BusinessHoursPolicy businessHoursPolicy = new BusinessHoursPolicy(appt);
            AppointmentSchedule appointmentSchedule = new AppointmentSchedule(businessHoursPolicy);
          //  var cursor = appt.Align(DateTimeOffset.Parse("2026-09-21T08:00:00Z"));

           

           // var isBussniessHours = businessHoursPolicy.IsWithinBusinessHours(cursor);

            AppointmentSlotFinder appointmentSlotFinder = new AppointmentSlotFinder(appt, appointmentSchedule, businessHoursPolicy);



            var slot = appointmentSlotFinder.FindNextSlot(DateTimeOffset.Parse("2026-09-21T08:00:00Z"), 48);
            try { if (slot is null) throw new InvalidOperationException("no slot"); }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            appointmentSchedule.TryBook(slot.Value);

            SmsReminderGenerator smsReminderGenerator = new SmsReminderGenerator();

            Console.WriteLine(smsReminderGenerator.SmsReminder(slot.Value, "0100"));

            Console.WriteLine("Done. Now split responsibilities — without breaking behavior.");



        }
    }
}
