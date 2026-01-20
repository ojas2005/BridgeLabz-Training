using System;
class Department<T> where T:CourseType
{
    private string DepartmentName;
    private List<Course<T>> courses=new List<Course<T>>();
    
    public Department(string departmentName)
    {
        DepartmentName=departmentName;
    }
    
    public void AddCourse(Course<T> course)
    {
        courses.Add(course);
        Console.WriteLine($"Course added to {DepartmentName}: {course.CourseName}");
    }
    
    public void DisplayAllCourses()
    {
        Console.WriteLine($"\n{DepartmentName} Courses");
        foreach(Course<T> course in courses)
        {
            course.DisplayCourseInfo();
        }
        Console.WriteLine();
    }
    
    public int GetCourseCount()
    {
        return courses.Count;
    }
}