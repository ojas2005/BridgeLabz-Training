using System;
class AssignmentCourse:CourseType
{
    public int AssignmentPercentage;
    
    public AssignmentCourse(int assignmentPercentage):base("assignment oriented")
    {
        AssignmentPercentage=assignmentPercentage;
    }
    
    public override void DisplayEvaluation()
    {
        Console.WriteLine($"evaluation Type: {EvaluationType}, sssignment percentage:- {AssignmentPercentage}%");
    }
}