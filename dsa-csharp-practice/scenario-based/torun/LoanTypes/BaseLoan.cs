using LoanBuddy.Interfaces;
using LoanBuddy.Models;

namespace LoanBuddy.LoanTypes
{
    public abstract class BaseLoan:IApprovable
    {
        protected Applicant applicant;
        protected LoanApplication loanApplication;
        protected double minCreditScore;
        protected double maxLoanToIncomeRatio;

        public BaseLoan(Applicant applicant,LoanApplication loanApplication)
        {
            this.applicant=applicant;
            this.loanApplication=loanApplication;
            minCreditScore=600;
            maxLoanToIncomeRatio=5.0;
        }

        public virtual bool ApproveLoan()
        {
            bool creditCheck=applicant.GetCreditScore()>=minCreditScore;
            bool incomeCheck=applicant.LoanAmount<=(applicant.Income*maxLoanToIncomeRatio);
            return creditCheck&&incomeCheck;
        }
        public abstract double CalculateEMI();
        protected double ComputeEMI(double principal, double monthlyRate, int totalMonths)
        {
            double numerator=principal*monthlyRate*Math.Pow(1+monthlyRate, totalMonths);
            double denominator=Math.Pow(1+monthlyRate, totalMonths)-1;
            return numerator/denominator;
        }
    }
}
