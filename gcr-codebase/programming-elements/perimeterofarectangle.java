import java.util.Scanner;

public class perimeterofarectangle {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int length = sc.nextInt();
        int width = sc.nextInt();
        int perimeter = 2*(length*width); //calculating perimeter
        System.out.println(perimeter);
        sc.close();
    }
}
