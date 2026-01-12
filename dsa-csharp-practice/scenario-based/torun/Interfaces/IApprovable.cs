namespace LoanBuddy.Interfaces
{
    public interface IApprovable
    {
        bool ApproveLoan();
        double CalculateEMI();
    }
}
