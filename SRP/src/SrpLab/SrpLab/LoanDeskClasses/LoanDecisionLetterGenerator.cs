using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.LoanDeskClasses
{
    public class LoanDecisionLetterGenerator
    {
        private readonly LoanRiskEvaluator loanRiskEvaluator;
        private readonly LoanDesk loanDesk;
        private readonly DocumentRequiredProvider documentRequiredProvider;

        public LoanDecisionLetterGenerator(LoanRiskEvaluator loanRiskEvaluator, LoanDesk loanDesk, DocumentRequiredProvider documentRequiredProvider)
        {
            this.loanRiskEvaluator = loanRiskEvaluator;
            this.loanDesk = loanDesk;
            this.documentRequiredProvider = documentRequiredProvider;
        }

        public string DecisionLetter(string applicantName)
        {
            // Legal/comms wording ≠ underwriting math.
            if (loanRiskEvaluator.IsEligible())
            {
                return $"Dear {applicantName},\nYour request for {loanDesk.RequestedAmount:C} is pre-approved (risk {loanRiskEvaluator.RiskScore():0}).\n" +
                       $"Please upload: {string.Join("; ", documentRequiredProvider.RequiredDocuments())}.\n";
            }

            return $"Dear {applicantName},\nWe are unable to approve {loanDesk.RequestedAmount:C} at this time.\n" +
                   $"Reference risk={loanRiskEvaluator.RiskScore():0}. You may reapply after improving documentation.\n";
        }
    }
}
