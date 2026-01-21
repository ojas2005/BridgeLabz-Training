public class RankGenerator
{
    public static Student[] GenerateRankList(IDistrict[] districts)
    {
        List<Student> allStudents = new List<Student>();

        foreach(District d in districts)
        {
            Student[] std = d.GetStudents();
            foreach (Student s in std)
                allStudents.Add(s);
        }
        Student[] rankedStudents = allStudents.ToArray();
        MergeSorter.MergeSort(rankedStudents);
        return rankedStudents;
    }
}
