using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.LoanDeskClasses
{
    public class LoanCsvExporter
    {
        private readonly LoanRiskEvaluator loanRiskEvaluator;
        private readonly LoanDesk loanDesk;
      //  private readonly DocumentRequiredProvider documentRequiredProvider;

        public LoanCsvExporter(LoanRiskEvaluator loanRiskEvaluator, LoanDesk loanDesk, DocumentRequiredProvider documentRequiredProvider)
        {
            this.loanRiskEvaluator = loanRiskEvaluator;
            this.loanDesk = loanDesk;
           // this.documentRequiredProvider = documentRequiredProvider;
        }

        public string UnderwriterCsvRow(string applicationId)
        {
            // Analytics export schema is yet another reason to change.
            return $"{applicationId},{loanDesk.CreditScore},{loanDesk.EmploymentMonths},{(loanDesk.HasCollateral ? 1 : 0)},{loanRiskEvaluator.RiskScore():0.00},{(loanRiskEvaluator.IsEligible() ? "Y" : "N")}";
        }
    }
}
