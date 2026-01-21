public class District : IDistrict{
    private int districtCode;
    private string districtName;
    Student[] students;
    int count=0;
    public District(int districtCode,string districtName,int size)
    {
        this.districtCode = districtCode;
        this.districtName = districtName;
        students = new Student[size];
    }
    public void AddStudent(Student s)
    {
        students[count] = s;
        count++;
    }
    public Student[] GetStudents()
    {
        Student[] result = new Student[count];
        for(int i=0;i<count;i++)
        {
            result[i] = students[i];
        }
        return result;
    }
    public string GetDistrictName()
    {
        return districtName;
    }

    

}