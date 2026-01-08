public class AcademicRecord
{
    public int id;
    public string fullName;
    public int yearOfBirth;
    public char performance;
    public AcademicRecord link;

    public AcademicRecord(int id,string fullName,int yearOfBirth,char performance)
    {
        this.id=id;
        this.fullName=fullName;
        this.yearOfBirth=yearOfBirth;
        this.performance=performance;
        this.link=null;
    }
}
