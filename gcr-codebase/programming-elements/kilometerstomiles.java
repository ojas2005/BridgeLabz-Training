import java.util.Scanner;
public class kilometerstomiles {
    public static void main(String[] args)
    {
        Scanner sc = new Scanner(System.in);
        float km = sc.nextFloat();
        float miles = km * 0.621371f;
        System.out.println(miles);
        sc.close();



    }
}
