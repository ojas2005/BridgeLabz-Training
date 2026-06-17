public interface IScoringEngine
{
    int CalculateScore(Student student);
    double CalculatePercentage(int score, int totalQuestions);
    char GetGrade(double percentage);
    void DisplayScoreReport(Student student, int score, int totalQuestions);
}
