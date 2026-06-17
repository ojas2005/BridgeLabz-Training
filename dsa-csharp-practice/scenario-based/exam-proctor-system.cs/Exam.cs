public class Exam
{
    public Question[] questions;
    public int totalQuestions;

    public Exam(int size)
    {
        totalQuestions = size;
        questions = new Question[size];
    }

    public void AddQuestion(int index, Question question)
    {
        if (index < totalQuestions)
        {
            questions[index] = question;
        }
    }

    public Question GetQuestion(int questionID)
    {
        for (int i = 0; i < totalQuestions; i++)
        {
            if (questions[i].ID == questionID)
            {
                return questions[i];
            }
        }
        return null;
    }
}
