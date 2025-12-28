using System;
class DateComparison{
    static void Main(){
        DateTime firstDate = DateTime.Parse(Console.ReadLine());
        DateTime secondDate = DateTime.Parse(Console.ReadLine());
        int ans = DateTime.Compare(firstDate,secondDate);
        if(ans>0)
        {
            Console.WriteLine("1st date is after 2nd date");
        }
        else if(ans=0)
        {
            Console.WriteLine("Both dates are same");
        }
        else{
            Console.WriteLine("1st date is before 2nd date");
        }

    }
}