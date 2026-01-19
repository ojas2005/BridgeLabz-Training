// Custom HashMap Implementation (without generics)
public class AnswerMap
{
    private int[] questionIDs;
    private string[] answers;
    private int count;
    private int maxSize;

    public AnswerMap(int size)
    {
        maxSize = size;
        questionIDs = new int[size];
        answers = new string[size];
        count = 0;
    }

    public void Put(int questionID, string answer)
    {
        // Check if question already exists
        for (int i = 0; i < count; i++)
        {
            if (questionIDs[i] == questionID)
            {
                answers[i] = answer;
                Console.WriteLine($"Answer for Question {questionID} updated");
                return;
            }
        }

        // Add new answer
        if (count < maxSize)
        {
            questionIDs[count] = questionID;
            answers[count] = answer;
            count++;
            Console.WriteLine($"Answer for Question {questionID} saved: {answer}");
        }
        else
        {
            Console.WriteLine("Answer map is full!");
        }
    }

    public string Get(int questionID)
    {
        for (int i = 0; i < count; i++)
        {
            if (questionIDs[i] == questionID)
            {
                return answers[i];
            }
        }
        return null;
    }

    public bool Contains(int questionID)
    {
        for (int i = 0; i < count; i++)
        {
            if (questionIDs[i] == questionID)
            {
                return true;
            }
        }
        return false;
    }

    public void DisplayAllAnswers()
    {
        if (count == 0)
        {
            Console.WriteLine("No answers saved!");
            return;
        }
        Console.WriteLine("\nAll Submitted Answers:");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"  Question {questionIDs[i]}: {answers[i]}");
        }
    }

    public int GetAnswerCount()
    {
        return count;
    }

    public int[] GetAllQuestionIDs()
    {
        int[] ids = new int[count];
        for (int i = 0; i < count; i++)
        {
            ids[i] = questionIDs[i];
        }
        return ids;
    }
}