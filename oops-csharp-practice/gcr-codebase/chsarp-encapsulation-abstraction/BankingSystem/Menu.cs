using System;

namespace BankApp
{
    internal class Menu
    {
        BankAccount[] accs=new BankAccount[3];
        int idx=0;

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("banking menu:");
                Console.WriteLine("1. add savings");
                Console.WriteLine("2. add current");
                Console.WriteLine("3. deposit");
                Console.WriteLine("4. show interest");
                Console.WriteLine("5. apply loan");
                Console.WriteLine("6. exit");
                int c=int.Parse(Console.ReadLine());

                switch (c)
                {
                    case 1:
                        AddAcc(new SavingsAccount());
                        break;
                    case 2:
                        AddAcc(new CurrentAccount());
                        break;
                    case 3:
                        DepositFunds();
                        break;
                    case 4:
                        PrintInterest();
                        break;
                    case 5:
                        GetLoan();
                        break;
                    case 6:
                        return;
                }
            }
        }

        void AddAcc(BankAccount acc)
        {
            if (idx >= accs.Length) return;

            Console.Write("account no: ");
            acc.SetAccNo(Convert.ToInt32(Console.ReadLine()));

            Console.Write("holder name: ");
            acc.SetHolder(Console.ReadLine());

            Console.Write("balance: ");
            acc.SetBal(Convert.ToDouble(Console.ReadLine()));

            accs[idx++]=acc;
        }

        void DepositFunds()
        {
            Console.Write("enter index: ");
            int i=Convert.ToInt32(Console.ReadLine());

            Console.Write("enter amount: ");
            double amt=Convert.ToDouble(Console.ReadLine());

            accs[i].Deposit(amt);
        }

        void PrintInterest()
        {
            for (int i=0; i < idx; i++)
            {
                BankAccount acc=accs[i];
                double inter=acc.GetInterest();
                Console.WriteLine(acc.Holder + " interest: " + inter);
            }
        }

        void GetLoan()
        {
            Console.Write("enter index: ");
            int i=Convert.ToInt32(Console.ReadLine());

            if (accs[i] is ILoanable ln)
            {
                ln.ApplyLoan();
            }
        }
    }
}
