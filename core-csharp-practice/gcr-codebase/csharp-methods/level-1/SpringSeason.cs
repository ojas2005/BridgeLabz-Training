using System;
class SpringSeason
{
    public static string SpringOrNot(int month,int day){
        //checking that the given month and day is in the valid range or not.
        if((month<1 || month >12) || (day>31 || day<1))
        {
            return "Enter a valid range";
        }
        else{
            //checking for months included in spring season
        if(month>=3 && month <=6)
        {
            //taking only days after 19th march so removing rest.
            if(month==3 && day<20)
            {
                return "Not a spring season";
            }

            //taking days till 20th june so removing rest.
            else if(month == 6 && day>20)
            {
                return "Not a spring season";
            }
            //after above statements we will be getting the spring season dates.
            else
            {
                return "Its a spring season";
            }
        }
    }
    static void Main()
        {
            //taking the month and day values as input.
            int month = int.Parse(Console.ReadLine());
            int day = int.Parse(Console.ReadLine());
            Console.WriteLine(SpringOrNot(month,day));
        }
    }
}
