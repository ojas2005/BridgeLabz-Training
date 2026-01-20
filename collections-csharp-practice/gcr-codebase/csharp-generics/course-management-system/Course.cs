using System;
class Course<T> where T:CourseType
{
    public string CourseCode;
    public string CourseName;
    public T EvaluationType;
    public int Credits;
    
    public Course(string courseCode,string courseName,T evaluationType,int credits)
    {
        CourseCode=courseCode;
        CourseName=courseName;
        EvaluationType=evaluationType;
        Credits=credits;
    }
    
    public void DisplayCourseInfo()
    {
        Console.WriteLine($"\nCourse: {CourseCode}-{CourseName}, credits: {Credits}");
        EvaluationType.DisplayEvaluation();
    }
}