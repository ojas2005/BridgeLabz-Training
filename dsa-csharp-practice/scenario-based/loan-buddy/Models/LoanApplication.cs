namespace LoanBuddy.Models
{
    public class LoanApplication
    {
        public string LoanType { get; set; }
        public int Term { get; set; }
        public double InterestRate { get; set; }
        public string Status { get; private set; }

        public LoanApplication(string loanType, int term, double interestRate)
        {
            LoanType=loanType;
            Term=term;
            InterestRate=interestRate;
            Status="pending";
        }
        public void SetStatus(string status)
        {
            Status=status;
        }
        public string GetStatus()
        {
            return Status;
        }
    }
}
