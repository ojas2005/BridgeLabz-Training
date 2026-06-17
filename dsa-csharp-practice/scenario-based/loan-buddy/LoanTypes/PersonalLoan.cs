using LoanBuddy.Models;

namespace LoanBuddy.LoanTypes
{
    public class PersonalLoan:BaseLoan
    {
        public PersonalLoan(Applicant applicant, LoanApplication loanApplication):base(applicant, loanApplication)
        {
            minCreditScore=650;
            maxLoanToIncomeRatio=3.0;
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
