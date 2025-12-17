import java.util.Scanner;
public class fibonacci {
    public static void main(String args[])
    {
        Scanner sc = new Scanner(System.in);
        int n = sc.nextInt();
        int a = 0;
        int b = 1;

        if(n==0)
        {
            System.out.print(""); //if the value of n is 0 we shoul not print anything.
        }
        else if(n==1)
        {
            System.out.print("0"); //if value of n is 1 then we will be printing 1st digit of the series(0).
        }
        else{
            System.out.print(a+" "+b); //printing first 2 digits of the series.
            while(n>2)
        {
            System.out.print(" ");
            System.out.print(a+b); //next digit is the sum of 2 previous digits.
            //swapping
            int temp = a; 
            a=b;
            b=temp+b;
            n--; //decrementing the value of n
        }
    }
    sc.close();
    }
    
}