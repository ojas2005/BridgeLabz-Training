class Program
{
    static void Main()
    {
        IDistrict[] districts = new IDistrict[10];
        int districtCount = 0;

        while(true)
        {
            Console.WriteLine("press 1 to add district");
            Console.WriteLine("press 2 to add student");
            Console.WriteLine("press 3 to generate rank List");
            Console.WriteLine("press 4 to exit");

            int choice = int.Parse(Console.ReadLine());

            if(choice==1)
            {
                Console.WriteLine("enter District Code");
                int code = int.Parse(Console.ReadLine());

                Console.WriteLine("enter District Name");
                string name = Console.ReadLine();

                Console.WriteLine("enter Max Students");
                int size = int.Parse(Console.ReadLine());

                districts[districtCount++] = new District(code, name, size);
            }
            else if(choice==2)
            {
                Console.WriteLine("select district index");
                for (int i = 0; i < districtCount; i++)
                    Console.WriteLine(i + " " + districts[i].GetDistrictName());

                int dIndex = int.Parse(Console.ReadLine());

                Console.WriteLine("enter name");
                string name = Console.ReadLine();

                Console.WriteLine("enter roll");
                int roll = int.Parse(Console.ReadLine());

                Console.WriteLine("enter score");
                int score = int.Parse(Console.ReadLine());

                districts[dIndex].AddStudent(new Student(name, " ", roll, score));
            }
            else if(choice==3)
            {
                IDistrict[] active = new IDistrict[districtCount];
                for (int i = 0;i<districtCount;i++)
                    active[i] = districts[i];

                Student[] rankList = RankGenerator.GenerateRankList(active);
                int rank = 1;
                foreach (Student s in rankList)
                    Console.WriteLine(rank++ + " " + s.getName() + " " + s.getDistrict() + " " + s.getScore());
            }
            else
                break;
        }
    }
}
