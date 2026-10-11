using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.LoanDeskClasses
{
    public class LoanRiskEvaluator
    {
        private readonly LoanDesk _loanDesk;

        public LoanRiskEvaluator(LoanDesk loanDesk)
        {
            _loanDesk = loanDesk;
        }

        public decimal RiskScore()
        {
            // Risk model will change with risk committee — not with letter templates.
            decimal score = 100m;
            score -= Math.Max(0, 700 - _loanDesk.CreditScore) * 0.15m;
            if (_loanDesk.EmploymentMonths < 6) score -= 20m;
            if (_loanDesk.RequestedAmount > 50_000m && !_loanDesk.HasCollateral) score -= 25m;
            if (_loanDesk.RequestedAmount > 150_000m) score -= 10m;
            return Math.Clamp(score, 0m, 100m);
        }

        public bool IsEligible() => RiskScore() >= 55m && _loanDesk.CreditScore >= 580;
    }
}
