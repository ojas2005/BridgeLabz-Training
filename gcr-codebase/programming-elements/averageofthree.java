import java.util.Scanner;

public class averageofthree {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int a = sc.nextInt();
        int b = sc.nextInt();
        int c = sc.nextInt();
        float avg = (a+b+c)/3.0f;
        System.out.println(avg);
        sc.close();
    }
}
