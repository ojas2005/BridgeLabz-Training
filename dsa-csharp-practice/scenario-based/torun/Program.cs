using LoanBuddy.Models;
using LoanBuddy.LoanTypes;
using LoanBuddy.Services;
class Program
{
    static void Main()
    {
        Applicant applicant1=new Applicant("Rahul Sharma",720,75000,120000);
        LoanApplication personalLoan=new LoanApplication("Personal",5,8.5);
        PersonalLoan personalLoanProcessor=new PersonalLoan(applicant1,personalLoan);

        LoanApprovalEngine engine=new LoanApprovalEngine();
        engine.ProcessLoan(personalLoanProcessor,personalLoan);
        double personalEMI=engine.GetMonthlyEMI(personalLoanProcessor);
        engine.DisplayLoanDetails(applicant1,personalLoan,personalEMI);

        Console.WriteLine(" ");

        Applicant applicant2=new Applicant("Anita Verma",680,95000,375000);
        LoanApplication homeLoan=new LoanApplication("Home",20,6.5);
        HomeLoan homeLoanProcessor=new HomeLoan(applicant2,homeLoan);

        engine.ProcessLoan(homeLoanProcessor,homeLoan);
        double homeEMI=engine.GetMonthlyEMI(homeLoanProcessor);
        engine.DisplayLoanDetails(applicant2,homeLoan,homeEMI);

        Console.WriteLine(" ");

        Applicant applicant3=new Applicant("Suresh Kumar",580,55000,25000);
        LoanApplication autoLoan=new LoanApplication("Auto",7,7.2);
        AutoLoan autoLoanProcessor=new AutoLoan(applicant3,autoLoan);

        engine.ProcessLoan(autoLoanProcessor,autoLoan);
        double autoEMI=engine.GetMonthlyEMI(autoLoanProcessor);
        engine.DisplayLoanDetails(applicant3,autoLoan,autoEMI);
    }
}
