using LoanBuddy.Interfaces;
using LoanBuddy.Models;

namespace LoanBuddy.Services
{
    public class LoanApprovalEngine
    {
        public void ProcessLoan(IApprovable loan, LoanApplication loanApplication)
        {
            bool isApproved=loan.ApproveLoan();
            if(isApproved)
            {
                loanApplication.SetStatus("approved");
            }
            else
            {
                loanApplication.SetStatus("rejected");
            }
        }
        public double GetMonthlyEMI(IApprovable loan)
        {
            return loan.CalculateEMI();
        }
        public void DisplayLoanDetails(Applicant applicant,LoanApplication loanApplication,double monthlyEmi)
        {
            Console.WriteLine("loan details");
            Console.WriteLine($"applicant name: {applicant.Name}");
            Console.WriteLine($"loan amount: {applicant.LoanAmount:f2}");
            Console.WriteLine($"loan type: {loanApplication.LoanType}");
            Console.WriteLine($"term: {loanApplication.Term} years");
            Console.WriteLine($"interest rate: {loanApplication.InterestRate}%");
            Console.WriteLine($"monthly emi: {monthlyEmi:f2}");
            Console.WriteLine($"status: {loanApplication.GetStatus()}");
        }

    }
}
