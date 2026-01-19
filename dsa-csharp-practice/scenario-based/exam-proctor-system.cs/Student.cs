// Student class
public class Student
{
    public int StudentID;
    public string Name;
    public QuestionStack navigationStack;
    public AnswerMap answers;
    public Exam exam;

    public Student(int id, string name, int maxStackSize, int maxAnswers, Exam examData)
    {
        StudentID = id;
        Name = name;
        navigationStack = new QuestionStack(maxStackSize);
        answers = new AnswerMap(maxAnswers);
        exam = examData;
    }
}