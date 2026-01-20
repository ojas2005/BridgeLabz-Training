using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        Department<ExamCourse> csDepartment=new Department<ExamCourse>("Computer Science");
        
        csDepartment.AddCourse(new Course<ExamCourse>("CS101","Introduction to Programming",new ExamCourse(70),3));
        csDepartment.AddCourse(new Course<ExamCourse>("CS201","Data Structures",new ExamCourse(75),4));
        csDepartment.DisplayAllCourses();
        
        Department<AssignmentCourse> mathDepartment=new Department<AssignmentCourse>("Mathematics");
        
        mathDepartment.AddCourse(new Course<AssignmentCourse>("MATH101","Calculus I",new AssignmentCourse(50),4));
        mathDepartment.AddCourse(new Course<AssignmentCourse>("MATH201","Linear Algebra",new AssignmentCourse(60),3));
        mathDepartment.DisplayAllCourses();
        
        Department<ProjectCourse> engineeringDepartment=new Department<ProjectCourse>("Engineering");
        
        engineeringDepartment.AddCourse(new Course<ProjectCourse>("ENG101","Introduction to Engineering",new ProjectCourse(80),3));
        engineeringDepartment.AddCourse(new Course<ProjectCourse>("ENG301","Capstone Project",new ProjectCourse(100),6));
        engineeringDepartment.DisplayAllCourses();
    }
}
