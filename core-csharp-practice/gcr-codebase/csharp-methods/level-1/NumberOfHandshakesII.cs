using System;
class NumberOfHandshakes{
    static void Main()
    {
        int numberOfStudents = int.Parse(Console.ReadLine()); //taking the input for number of students.
        int maxNumberOfHandshakes = (numberOfStudents*(numberOfStudents-1))/2; //formula to count number of handshakes
        Console.WriteLine($"Max number of handshakes : {maxNumberOfHandshakes}"); //Printing the count of the handshakes.
    }
}