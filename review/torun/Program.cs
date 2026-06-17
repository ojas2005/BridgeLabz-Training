class Program
{
    static void Main()
    {
        Cafeteria cafe=new Cafeteria();
        while(true)
        {
            Console.WriteLine("Cafeteria menu app");
            Console.WriteLine("press 1 if you are a User");
            Console.WriteLine("press 2 if you are a  Manager");
            Console.WriteLine("press 3 to Exit");
            int choice=int.Parse(Console.ReadLine());
            if (choice== 1)
            {
                User user=new User(cafe);
                user.UserMenu();
            }
            else if (choice==2)
            {
                Manager manager=new Manager(cafe);
                manager.ManagerMenu();
            }
            else
            {
                break;
            }
        }
    }
}
