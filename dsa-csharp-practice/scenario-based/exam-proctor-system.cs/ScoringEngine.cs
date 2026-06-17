using System;

public class ScoringEngine : IScoringEngine
{
    public int CalculateScore(Student student)
    {
        int score = 0;
        int[] answeredQuestions = student.answers.GetAllQuestionIDs();

        for (int i = 0; i < answeredQuestions.Length; i++)
        {
            int questionID = answeredQuestions[i];
            Question question = student.exam.GetQuestion(questionID);
            string studentAnswer = student.answers.Get(questionID);

            if (question != null && IsAnswerCorrect(studentAnswer, question.CorrectAnswer))
            {
                score++;
            }
        }

        return score;
    }

    private bool IsAnswerCorrect(string studentAnswer, string correctAnswer)
    {
        if (studentAnswer == null)
        {
            return false;
        }

        return studentAnswer.ToLower() == correctAnswer.ToLower();
    }

    public double CalculatePercentage(int score, int totalQuestions)
    {
        if (totalQuestions == 0)
        {
            return 0;
        }

        return (double)score / totalQuestions * 100;
    }

    public char GetGrade(double percentage)
    {
        if (percentage >= 90) return 'A';
        if (percentage >= 80) return 'B';
        if (percentage >= 70) return 'C';
        if (percentage >= 60) return 'D';
        return 'F';
    }

    public void DisplayScoreReport(Student student, int score, int totalQuestions)
    {
        double percentage = CalculatePercentage(score, totalQuestions);
        char grade = GetGrade(percentage);

        Console.WriteLine("Student Name: " + student.Name);
        Console.WriteLine("Student ID: " + student.StudentID);
        Console.WriteLine("Score: " + score + "/" + totalQuestions);
        Console.WriteLine("Percentage: " + percentage.ToString("F2") + "%");
        Console.WriteLine("Grade: " + grade);
    }
}
