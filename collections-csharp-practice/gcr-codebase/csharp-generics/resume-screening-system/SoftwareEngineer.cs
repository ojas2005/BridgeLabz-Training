class SoftwareEngineer:JobRole
{
    public int YearsRequired;
    
    public SoftwareEngineer(int yearsRequired):base("Software Engineer","C#, .NET, SQL, Problem Solving")
    {
        YearsRequired=yearsRequired;
    }
    
    public override void DisplayJobRequirements()
    {
        Console.WriteLine($"Role: {RoleName}, Required Skills: {RequiredSkills}, Years: {YearsRequired}+");
    }
}
