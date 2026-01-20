using System;
class ExamCourse:CourseType
{
    public int ExamPercentage;
    
    public ExamCourse(int examPercentage):base("Exam-Based")
    {
        ExamPercentage=examPercentage;
    }
    
    public override void DisplayEvaluation()
    {
        Console.WriteLine($"Evaluation Type: {EvaluationType}, Exam Percentage: {ExamPercentage}%");
    }
}