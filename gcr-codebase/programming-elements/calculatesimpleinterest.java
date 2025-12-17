import java.util.Scanner;

public class calculatesimpleinterest {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int p = sc.nextInt(); //enter the principal amount
        int r = sc.nextInt(); //enter the rate of interest
        int t = sc.nextInt(); //enter the time
        float SI = (p*r*t)/100; //formula for calculating simple interest
        System.out.println(SI);
        sc.close();;
    }
}
