import java.util.Scanner;

public class celsiustofahrenheit {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        float celcius = sc.nextFloat();
        float fahrenheit = (celcius*1.8f) + 32;
        System.out.println(fahrenheit);
        sc.close();
    }
}
