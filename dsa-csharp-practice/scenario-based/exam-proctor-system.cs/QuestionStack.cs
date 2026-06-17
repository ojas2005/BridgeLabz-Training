public class QuestionStack
{
    private int[] questions;
    private int top;
    private int maxSize;

    public QuestionStack(int size)
    {
        maxSize = size;
        questions = new int[size];
        top = -1;
    }

    public void Push(int questionID)
    {
        if (top < maxSize - 1)
        {
            questions[++top] = questionID;
            Console.WriteLine($"Navigated to Question {questionID}");
        }
        else
        {
            Console.WriteLine("Stack is full!");
        }
    }

    public int Pop()
    {
        if (top >= 0)
        {
            int question = questions[top];
            top--;
            Console.WriteLine($"Returned to Question {question}");
            return question;
        }
        Console.WriteLine("Stack is empty!");
        return -1;
    }

    public int Peek()
    {
        if (top >= 0)
        {
            return questions[top];
        }
        return -1;
    }

    public bool IsEmpty()
    {
        return top == -1;
    }

    public void DisplayNavigationHistory()
    {
        if (IsEmpty())
        {
            Console.WriteLine("No navigation history!");
            return;
        }
        Console.WriteLine("\nNavigation History (Last to First):");
        for (int i = top; i >= 0; i--)
        {
            Console.WriteLine($"  Question {questions[i]}");
        }
    }
}