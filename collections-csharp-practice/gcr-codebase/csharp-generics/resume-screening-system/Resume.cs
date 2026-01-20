class Resume<T> where T:JobRole
{
    public string CandidateName;
    public string Email;
    public double ExperienceYears;
    public T TargetRole;
    public bool IsQualified;
    
    public Resume(string candidateName,string email,double experienceYears,T targetRole)
    {
        CandidateName=candidateName;
        Email=email;
        ExperienceYears=experienceYears;
        TargetRole=targetRole;
        IsQualified=false;
    }
    
    public void DisplayResumeInfo()
    {
        Console.WriteLine($"\nCandidate: {CandidateName}, Email: {Email}, Experience: {ExperienceYears} years");
        TargetRole.DisplayJobRequirements();
        Console.WriteLine($"Status: {(IsQualified?" QUALIFIED":" NOT QUALIFIED")}");
    }
}