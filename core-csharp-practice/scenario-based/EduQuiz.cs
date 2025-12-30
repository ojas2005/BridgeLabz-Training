using System;
class EduQuiz{

    static bool[] CorrectOrNot(string[] answer,string[] correctAnswer)
    {
        bool[] result = new bool[10];
        for(int i = 0;i<correctAnswer.Length;i++)
        {
            result[i] = string.Equals(answer[i],correctAnswer[i],StringComparison.OrdinalIgnoreCase);
        }
        return result;
    }
    static void Main()
    {
        int numberOfQuestions = 2;
        string[] correctAnswer = new string[numberOfQuestions];
        string[] answer = new string[numberOfQuestions];
        int marks = 0;

        for(int i = 0;i<correctAnswer.Length;i++)
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine($"Enter Student's answer for Question number {i+1}");
            answer[i] = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine($"Enter actual answer for Question number {i+1}");
            correctAnswer[i] = Console.ReadLine();
            Console.WriteLine("");
            
        }
        bool[] result=CorrectOrNot(answer,correctAnswer);
        for(int i = 0;i<correctAnswer.Length;i++){
            Console.WriteLine("");
            
            if(result[i]==true)
            {
                Console.WriteLine($"Answer for Question number {i+1} is Correct");
                marks++;
            }
            else{
                Console.WriteLine($"Answer for Question number {i+1} is Incorrect");
            }
        }


        float percentageMarks = (marks*100f)/numberOfQuestions;
        if(marks<4){
            Console.WriteLine($"Student Secured {percentageMarks}% marks and failed");
        }
        else{
            Console.WriteLine($"Student Secured {percentageMarks}% marks and Passed");
        }
    }
}
