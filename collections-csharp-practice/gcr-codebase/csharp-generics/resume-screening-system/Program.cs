using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Software Engineer Pipeline
        ScreeningPipeline<SoftwareEngineer> sePipeline = new ScreeningPipeline<SoftwareEngineer>();

        sePipeline.SubmitResume(new Resume<SoftwareEngineer>("Rahul Sharma", "rahul.sharma@gmail.com", 5, new SoftwareEngineer(3)));

        sePipeline.SubmitResume(new Resume<SoftwareEngineer>("Ankit Verma", "ankit.verma@gmail.com", 2, new SoftwareEngineer(3)));

        sePipeline.SubmitResume(new Resume<SoftwareEngineer>("Neha Singh", "neha.singh@gmail.com", 7, new SoftwareEngineer(3)));

        sePipeline.ScreenResumes();
        sePipeline.DisplayQualifiedCandidates();


        // Data Scientist Pipeline
        ScreeningPipeline<DataScientist> dsPipeline = new ScreeningPipeline<DataScientist>();

        dsPipeline.SubmitResume(new Resume<DataScientist>("Priya Patel", "priya.patel@gmail.com", 4, new DataScientist(3)));

        dsPipeline.SubmitResume(new Resume<DataScientist>("Amit Kumar", "amit.kumar@gmail.com", 2, new DataScientist(4)));

        dsPipeline.SubmitResume(new Resume<DataScientist>("Sneha Iyer", "sneha.iyer@gmail.com", 6, new DataScientist(3)));

        dsPipeline.ScreenResumes();
        dsPipeline.DisplayQualifiedCandidates();

        ScreeningPipeline<ProjectManager> pmPipeline = new ScreeningPipeline<ProjectManager>();

        pmPipeline.SubmitResume(new Resume<ProjectManager>("Vikram Malhotra", "vikram.malhotra@gmail.com", 8, new ProjectManager(5)));

        pmPipeline.SubmitResume(new Resume<ProjectManager>("Pooja Mehta", "pooja.mehta@gmail.com", 3, new ProjectManager(5)));

        pmPipeline.ScreenResumes();
        pmPipeline.DisplayQualifiedCandidates();
    }
}
