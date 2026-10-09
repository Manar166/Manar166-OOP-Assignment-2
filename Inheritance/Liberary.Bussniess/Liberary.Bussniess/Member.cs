using SwiftBite.Common;

namespace Liberary.Bussniess
{
    public class Member:Person
    {
       private readonly List<Loan> _loans=new();



        public int MaxLoans { get; } 

        public double DiscountPrecentage { get; protected set; }

        public IReadOnlyList<Loan> Loans => _loans;

        protected Member(string fullName,string phoneNimber ,int maxLoan,double discountPrecent)
            : base(fullName,phoneNimber)
        {
            MaxLoans = maxLoan;
            DiscountPrecentage = discountPrecent;
          


        }
        public bool CanBorrow()
        {
            return _loans.Count < MaxLoans;
        }

        public void AddLoanToHistory(Loan loan)
        {

            Guard.Against(loan is null, "Loan is null");
            Guard.Against(!CanBorrow(), $"you can not loan more than {MaxLoans}");
            _loans.Add(loan);
        }

        public void ShowLoansHistory()
        {
            foreach (var loan in Loans)
            {
                Console.WriteLine($"{loan.LoanId} ,{loan.BorrowDate}"); 
            }
        }




    }

   
}
