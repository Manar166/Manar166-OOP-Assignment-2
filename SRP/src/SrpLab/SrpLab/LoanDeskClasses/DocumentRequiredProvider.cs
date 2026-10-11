using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.LoanDeskClasses
{
    public class DocumentRequiredProvider
    {
        private readonly LoanDesk loanDesk;
        private readonly LoanRiskEvaluator riskCalculator;

        public DocumentRequiredProvider(LoanDesk loanDesk, LoanRiskEvaluator riskCalculator)
        {
            this.loanDesk = loanDesk;
            this.riskCalculator = riskCalculator;
        }

        public IReadOnlyList<string> RequiredDocuments()
        {
            // Compliance checklist changes with regulation, independently of risk formula.
            var docs = new List<string> { "National ID", "Proof of income (3 months)" };
            if (loanDesk.RequestedAmount > 40_000m) docs.Add("Bank statements (6 months)");
            if (loanDesk.HasCollateral) docs.Add("Collateral ownership deed");
            if (loanDesk.EmploymentMonths < 12) docs.Add("Employer letter");
            if (!riskCalculator.IsEligible()) docs.Add("Manual underwriter referral form");
            return docs;
        }
    }
}
