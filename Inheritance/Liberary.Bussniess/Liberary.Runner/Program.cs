using Liberary.Bussniess;

namespace Liberary.Runner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("  SIMULATION ACADEMY - LIBRARY SYSTEM DEMO");
            Console.WriteLine("==================================================\n");

            // =========================================================================
            // 1.COMPILE - TIME CONSTRAINTS(MUST NOT COMPILE - COMMENTED OUT)
            // =========================================================================
            ///*
            // 1. Cannot instantiate base/abstract-like types with protected constructors directly:
            //Person person = new Person( "John Doe", "12345",0); // must NOT compile
            //Member member = new Member( "Jane Doe", "54321", 3); // must NOT compile
            //Staff staff = new Staff( "Alex Smith", "11111", DateTime.Now, 3000); // must NOT compile
           // LibraryItem item = new LibraryItem( "Generic Item", 7, 1.0); // must NOT compile

            // 2. Encapsulation checks: Properties have no public setters or read-only collections

            StudentMember studentDemo = StudentMember.Create( "Ali Hassan", "0500000000");
           // studentDemo.FullName = "New Name"; // must NOT compile
            //studentDemo.Loans.Add(null); //  NOT compile (IReadOnlyList has no Add)

            Book bookDemo = Book.Create( "C# in Depth", 2.0);
           // bookDemo.IsOnLoan = true; // must NOT compile (private set)



             //=========================================================================
             //2.RUNTIME FAILURES & RULE CHECKS(TRY / CATCH)
             //=========================================================================
                    Console.WriteLine("--- 1. TESTING REJECTED ACTIONS (RUNTIME EXCEPTIONS) ---");

            // أ. محاولة إعارة عنصر مسحوب (Withdrawn Item)
            try
            {
                Book withdrawnBook = Book.Create("Old Encyclopedia", 1.0);
              
                withdrawnBook.Withdraw();
                StudentMember student = StudentMember.Create( "Ahmad Ali", "0551111111");

                Console.WriteLine("Attempting to borrow a withdrawn book...");
                Loan invalidLoan = new Loan( DateTime.Now, student, withdrawnBook);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[REJECTED]: {ex.Message}");
            }

            // ب. محاولة إعارة عنصر مستعار حالياً (Already On Loan)
            try
            {
                Dvd activeDvd = Dvd.Create("Inception DVD", 3.0);
                StudentMember student1 = StudentMember.Create("Sara Omar", "0552222222");
                StudentMember student2 = StudentMember.Create("Khaled Noor", "0553333333");

                Loan loan1 = new Loan(DateTime.Now, student1, activeDvd);
                Console.WriteLine("Attempting to borrow an item already on loan...");
                Loan loan2 = new Loan(DateTime.Now, student2, activeDvd);
               

              
               
            }
            
            

            catch (Exception ex)
            {
                Console.WriteLine($"[REJECTED]: {ex.Message}");
            }

            // ج. تجاوز الحد الأقصى للإعارة للـ Student Member (الحد الأقصى هو 3)
            try
            {
                StudentMember student = StudentMember.Create( "Fahad Mustafa", "0554444444");
                Book b1 = Book.Create( "Book 1", 1.0);
                Book b2 = Book.Create( "Book 2", 1.0);
                Book b3 = Book.Create( "Book 3", 1.0);
                Book b4 = Book.Create( "Book 4", 1.0);

                student.AddLoanToHistory(new Loan( DateTime.Now, student, b1));
                student.AddLoanToHistory(new Loan( DateTime.Now, student, b2));
                student.AddLoanToHistory(new Loan( DateTime.Now, student, b3));
                // student.ShowLoansHistory();

                Console.WriteLine("Attempting student 4th loan (Max is 3)...");
                student.AddLoanToHistory(new Loan( DateTime.Now, student, b4));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[REJECTED]: {ex.Message}");
            }
                   Console.WriteLine();


            // =========================================================================
            // 3. STAFF POLYMORPHISM & MONTHLY PAY (LIST OF STAFF)
            // =========================================================================
            Console.WriteLine("--- 2. STAFF ROSTER & MONTHLY PAY ---");
            List<Staff> staffList=new List<Staff>
                            {
                                Liberarian.Create( "Mona Hassan", "0561111111", new DateTime(2020, 1, 1), 5000),
                                HeadLiberarian.Create( "Dr. Tareq", "0562222222", new DateTime(2015, 5, 12), 8000),
                                Shelver.Create( "Youssef Zaid", "0563333333", new DateTime(2022, 3, 15), 3500, "Fiction Section")
                            };

            foreach (var staffMember in staffList)
            {
                double pay =
                staffMember is HeadLiberarian head ?  head.GetMonthlyPay(): staffMember.GetMonthlyPay();


                Console.WriteLine($"Staff: {staffMember.FullName,-15} | Role: {staffMember.GetType().Name,-13} | Monthly Pay: ${pay:N2}");

            }





            // =========================================================================
            // 4. ITEMS HIERARCHY & RATES (LIST OF LIBRARY ITEMS)
            // =========================================================================
            Console.WriteLine("--- 3. LIBRARY ITEMS CATALOG & FEES ---");
            List<LibraryItem> itemList = new List<LibraryItem>
                            {
                                Book.Create( "Clean Code", 2.0),
                                Dvd.Create( "Interstellar", 3.0),
                                Magazine.Create("National Geographic", 4.0)
                            };

            foreach (LibraryItem item in itemList)
            {
                // حساب غرامة التأخير الخاصة بكل عنصر (Book: 1x, DVD: 2x, Magazine: 0.5x)
                double dailyFee;
                if (item is Dvd dvd) dailyFee = dvd.GetDailyLateFee();
                else if (item is Magazine magazine) dailyFee = magazine.GetDailyLateFee();
                else dailyFee = item.GetDailyLateFee();
                Console.WriteLine($"Item: {item.Title,-22} | Type: {item.GetType().Name,-8} | Period: {item.LoanPeriodDays} Days | Daily Fee: ${dailyFee:F2}");
            }
            Console.WriteLine();


            // =========================================================================
            // 5. PREMIUM MEMBER OVERDUE DVD RETURN
            // =========================================================================
            Console.WriteLine("--- 4. PREMIUM MEMBER OVERDUE RETURN DEMO ---");

            // إنشاء عضو Premium مع خصم 10% على الغرامات
            PerimuimMember premiumMember = PerimuimMember.Create( "Omar Farooq", "0577777777", 10.0);
            Dvd movieDvd = Dvd.Create( "Oppenheimer", 5.0); // DVD Base Fee = $5.0 -> Daily Fee = $10.0
            //Console.WriteLine(movieDvd.GetDailyLateFee());

            DateTime borrowDate = DateTime.Now.AddDays(-12); 
            Loan premiumLoan = new Loan( borrowDate, premiumMember, movieDvd);

            // تاريخ الإرجاع الفعلي اليوم (تأخير 5 أيام عن DueDate)
            DateTime actualReturnDate = DateTime.Now;
            premiumLoan.ReturnLoan(actualReturnDate);

            Console.WriteLine($"Member: {premiumMember.FullName} (Premium)");
            Console.WriteLine($"Item Borrowed: {movieDvd.Title} (DVD)");
            Console.WriteLine($"Borrow Date: {premiumLoan.BorrowDate:yyyy-MM-dd}");
            Console.WriteLine($"Due Date:    {premiumLoan.DueDate:yyyy-MM-dd} (Automatically calculated 7 days)");
            Console.WriteLine($"Return Date: {premiumLoan.ReturnDate:yyyy-MM-dd}");
            Console.WriteLine($"Late Fee:    ${premiumLoan.CalculateLateFee(actualReturnDate):F2} (Base $10/day * 5 days = $50 minus 10% discount)");
            Console.WriteLine($"Reward Points: {premiumMember.GetTotalPoints()} Points (Earned 5 points for return)");
            Console.WriteLine();


            // =========================================================================
            // 6. REJECTED LOAN STATUS STATE TRANSITIONS
            // =========================================================================
            Console.WriteLine("--- 5. INVALID LOAN STATE TRANSITIONS ---");

           // (Return Twice)
            try
            {
                Console.WriteLine("Attempting to return an already returned loan...");
                premiumLoan.ReturnLoan(DateTime.Now); // إرجاع ثانٍ
                Console.WriteLine("[INFO]: Second return was ignored/rejected gracefully (Status remains Returned).");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[REJECTED]: {ex.Message}");
            }

            //  (Mark Returned Loan as Lost)
            try
            {
                Console.WriteLine("Attempting to mark a returned loan as lost...");
                premiumLoan.MarkAsLost();
                if (premiumLoan.Status == LoanStatus.Returned)
                {
                    Console.WriteLine("[REJECTED]: Cannot mark a returned loan as lost! Loan status remained 'Returned'.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[REJECTED]: {ex.Message}");
            }

            Console.WriteLine("\n==================================================");
            Console.WriteLine("  ALL TESTS COMPLETED SUCCESSFULLY!");
            Console.WriteLine("==================================================");
        }
    }
    }
    
