using System;
class CourseManagement
    {
        //Initialising the Attributes
        static string university = "GLA University";
        string courseName;
        int duration;
        double fee;
        //creating constructor
        public CourseManagement(string courseName,int duration, double fee)
        {
            this.courseName = courseName;
            this.duration = duration;  
            this.fee = fee;
        }
        //display method
        public void DisplayCourseDetails()
        {
            Console.WriteLine($"Course name : {courseName}, duration: {duration}, fee {fee}");
        }
        // updating the name of the university
        public static void UpdateInstituteName(string name)
        {
            university = name;
            Console.WriteLine($"the updated name of the university is {university}");
        }

    }

