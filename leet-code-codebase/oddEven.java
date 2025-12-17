import java.util.Scanner;

public class oddEven {
    public static void main(String[] args) {
        
    Scanner sc = new Scanner(System.in);
    int n = sc.nextInt();
    if(n%2==0)
    {
        System.err.println("even");
    }
    else
    {
        System.err.println("odd");
    }
    sc.close();
    }
}
