public class Student{
    private string name;
    private string district;
    private int rollNumber;
    private int score;
    public Student(string name,string district,int rollNumber,int score)
    {
        this.name = name;
        this.district = district;
        this.rollNumber = rollNumber;
        this.score = score;
    }
    public string getName()
    {
        return name;
    }
    public string getDistrict()
    {
        return district;
    }
    public int getScore()
    {
        return score;
    }
    public int getRoll()
    {
        return rollNumber;
    }
}