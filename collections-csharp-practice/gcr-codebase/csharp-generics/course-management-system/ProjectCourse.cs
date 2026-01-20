using System;
class ProjectCourse:CourseType
{
    public int ProjectPercentage;
    
    public ProjectCourse(int projectPercentage):base("project oriented")
    {
        ProjectPercentage=projectPercentage;
    }
    
    public override void DisplayEvaluation()
    {
        Console.WriteLine($"evaluation type: {EvaluationType}, project percentage:- {ProjectPercentage}%");
    }
}
