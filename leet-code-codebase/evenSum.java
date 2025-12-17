import java.util.Scanner;

public class evenSum {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = sc.nextInt();
        int evenSum = 0;
        for(int i=0;i<=n;i++)
        {
            if(i%2==0)
            {
            evenSum+=i;
            }

        }
        sc.close();
        System.out.println(evenSum);
    }
}
