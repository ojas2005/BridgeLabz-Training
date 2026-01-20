class ProjectManager:JobRole
{
    public int YearsRequired;
    
    public ProjectManager(int yearsRequired):base("Project Manager","Leadership, Communication, Agile, Risk Management")
    {
        YearsRequired=yearsRequired;
    }
    
    public override void DisplayJobRequirements()
    {
        Console.WriteLine($"Role: {RoleName}, Required Skills: {RequiredSkills}, Years: {YearsRequired}+");
    }
}
