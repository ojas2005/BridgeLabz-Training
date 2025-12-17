import java.util.Scanner;

public class volumeofcylinder {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        float radius = sc.nextFloat();
        float h = sc.nextFloat();
        float pi = 3.14f;
        float volume = pi * radius * radius * h;
        System.out.println(volume);
        sc.close();
    }
}
