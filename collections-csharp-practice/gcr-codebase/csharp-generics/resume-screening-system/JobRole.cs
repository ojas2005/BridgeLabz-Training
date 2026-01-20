abstract class JobRole
{
    public string RoleName;
    public string RequiredSkills;
    
    public JobRole(string roleName,string requiredSkills)
    {
        RoleName=roleName;
        RequiredSkills=requiredSkills;
    }
    
    public abstract void DisplayJobRequirements();
}