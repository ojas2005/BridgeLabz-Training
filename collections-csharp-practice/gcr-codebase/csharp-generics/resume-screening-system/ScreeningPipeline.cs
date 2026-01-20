class ScreeningPipeline<T> where T:JobRole
{
    private List<Resume<T>> allResumes=new List<Resume<T>>();
    private List<Resume<T>> qualifiedResumes=new List<Resume<T>>();
    
    public void SubmitResume(Resume<T> resume)
    {
        allResumes.Add(resume);
        Console.WriteLine($"resume submitted:- {resume.CandidateName}");
    }
    
    public void ScreenResumes()
    {
        qualifiedResumes.Clear();
        Console.WriteLine("\nStarting Resume Screening\n");
        
        foreach(Resume<T> resume in allResumes)
        {
            SoftwareEngineer se=resume.TargetRole as SoftwareEngineer;
            if(se!=null)
            {
                if(resume.ExperienceYears>=se.YearsRequired)
                {
                    resume.IsQualified=true;
                    qualifiedResumes.Add(resume);
                }
            }
            
            DataScientist ds=resume.TargetRole as DataScientist;
            if(ds!=null)
            {
                if(resume.ExperienceYears>=ds.YearsRequired)
                {
                    resume.IsQualified=true;
                    qualifiedResumes.Add(resume);
                }
            }
            
            ProjectManager pm=resume.TargetRole as ProjectManager;
            if(pm!=null)
            {
                if(resume.ExperienceYears>=pm.YearsRequired)
                {
                    resume.IsQualified=true;
                    qualifiedResumes.Add(resume);
                }
            }
            
            resume.DisplayResumeInfo();
        }
    }
    
    public void DisplayQualifiedCandidates()
    {
        Console.WriteLine($"\nQualified Candidates ({qualifiedResumes.Count}/{allResumes.Count})");
        foreach(Resume<T> resume in qualifiedResumes)
        {
            Console.WriteLine($"{resume.CandidateName} - {resume.TargetRole.RoleName}");
        }
        Console.WriteLine();
    }
}