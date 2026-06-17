using LoanBuddy.Models;

namespace LoanBuddy.LoanTypes
{
    public class HomeLoan:BaseLoan
    {
        public HomeLoan(Applicant applicant, LoanApplication loanApplication):base(applicant, loanApplication)
        {
            minCreditScore=700;
            maxLoanToIncomeRatio=6.0;
        }
        public override double CalculateEMI()
        {
            double principal=applicant.LoanAmount;
            double annualRate=loanApplication.InterestRate;
            double monthlyRate=annualRate/(12*100);
            int totalMonths=loanApplication.Term*12;
            return ComputeEMI(principal, monthlyRate, totalMonths);
        }
    }
}
