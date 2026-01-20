abstract class CourseType
{
    public string EvaluationType;
    
    public CourseType(string evaluationType)
    {
        EvaluationType=evaluationType;
    }
    
    public abstract void DisplayEvaluation();
}
