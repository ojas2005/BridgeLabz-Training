import java.util.Scanner;

public class factorial {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = sc.nextInt();
        int i = n;
        if(n==0) System.out.print("1");
        else{
        while(i>1)
        {
            n = n*(i-1);
            i--;
        }
        System.err.print(n);
        }
        sc.close();
     
    }
}
