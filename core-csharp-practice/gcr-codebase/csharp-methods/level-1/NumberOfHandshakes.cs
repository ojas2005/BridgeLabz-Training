using System;
class NumberOfHandshakes{
    public static int NumberOfHandshake(int numberOfStudents){
        int maxNumberOfHandshakes = (numberOfStudents*(numberOfStudents-1))/2;
        return maxNumberOfHandshakes;
    }
    static void Main()
    {
        int numberOfStudents = int.Parse(Console.ReadLine()); //taking the input for number of students.
        int result = NumberOfHandshake(numberOfStudents);
        Console.WriteLine($"Max number of handshakes : {result}");  //Printing the count of the handshakes.
    }
}