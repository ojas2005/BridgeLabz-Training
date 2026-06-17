namespace LoanBuddy.Models
{
    public class Applicant
    {
        private int creditScore;
        public string Name { get; set; }
        public double Income { get; set; }
        public double LoanAmount { get; set; }

        public Applicant(string name, int creditScore, double income, double loanAmount)
        {
            Name=name;
            this.creditScore=creditScore;
            Income=income;
            LoanAmount=loanAmount;
        }
        public int GetCreditScore()
        {
            return creditScore;
        }
        private void SetCreditScore(int score)
        {
            creditScore=score;
        }
    }
}
