class DataScientist:JobRole
{
    public int YearsRequired;
    
    public DataScientist(int yearsRequired):base("Data Scientist","Python, Machine Learning, Statistics, SQL")
    {
        YearsRequired=yearsRequired;
    }
    
    public override void DisplayJobRequirements()
    {
        Console.WriteLine($"Role: {RoleName}, Required Skills: {RequiredSkills}, Years: {YearsRequired}+");
    }
}