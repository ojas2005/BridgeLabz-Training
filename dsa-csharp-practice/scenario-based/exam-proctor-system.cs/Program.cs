using System;

public class Program
{
    public static void Main()
    {
        Exam exam=CreateExam();
        IScoringEngine scoringEngine=new ScoringEngine();

        Student student=null;
        bool exit=false;

        while (!exit)
        {
            Console.WriteLine("press 1 to create student");
            Console.WriteLine("press 2 to navigate question");
            Console.WriteLine("press 3 to submit answer");
            Console.WriteLine("press 4 to view navigation history");
            Console.WriteLine("press 5 to view submitted answers");
            Console.WriteLine("press 6 to submit exam");
            Console.WriteLine("press 0 to exit");
            Console.Write("enter your choice here:- ");

            int choice=Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    student=CreateStudent(exam);
                    break;

                case 2:
                    if (student==null)
                    {
                        Console.WriteLine("create student first");
                        break;
                    }
                    Console.Write("enter question number to navigate: ");
                    int qNav=Convert.ToInt32(Console.ReadLine());
                    student.navigationStack.Push(qNav);
                    break;

                case 3:
                    if (student==null)
                    {
                        Console.WriteLine("create student first");
                        break;
                    }
                    Console.Write("enter question number: ");
                    int qAns=Convert.ToInt32(Console.ReadLine());
                    Console.Write("enter answer: ");
                    string answer=Console.ReadLine();
                    student.answers.Put(qAns,answer);
                    break;

                case 4:
                    if (student!=null)
                        student.navigationStack.DisplayNavigationHistory();
                    break;

                case 5:
                    if (student!=null)
                        student.answers.DisplayAllAnswers();
                    break;

                case 6:
                    if (student==null)
                    {
                        Console.WriteLine("create student first");
                        break;
                    }
                    int score=scoringEngine.CalculateScore(student);
                    scoringEngine.DisplayScoreReport(student,score,exam.totalQuestions);
                    break;

                case 0:
                    exit=true;
                    break;

                default:
                    Console.WriteLine("choose a valid option");
                    break;
            }
        }
    }

    private static Exam CreateExam()
    {
        Exam exam=new Exam(5);
        exam.AddQuestion(0,new Question(1,"What is 2 + 2?","4"));
        exam.AddQuestion(1,new Question(2,"Capital of India?","New Delhi"));
        exam.AddQuestion(2,new Question(3,"What is 6 * 5?","30"));
        exam.AddQuestion(3,new Question(4,"National animal of India?","Tiger"));
        exam.AddQuestion(4,new Question(5,"Chemical symbol of Water?","H2O"));
        return exam;
    }

    private static Student CreateStudent(Exam exam)
    {
        Console.Write("enter student id: ");
        int id=Convert.ToInt32(Console.ReadLine());

        Console.Write("enter student name: ");
        string name=Console.ReadLine();

        Student student=new Student(id,name,10,10,exam);
        Console.WriteLine("student created successfully");
        return student;
    }
}
