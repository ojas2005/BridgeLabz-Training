class Manager
{
    Cafeteria cafe;
    public Manager(Cafeteria cafe)
    {
        this.cafe=cafe;
    }
    public void ManagerMenu()
    {
        while (true)
        {
            Console.WriteLine("manager menu");
            Console.WriteLine("press 1 to view menu");
            Console.WriteLine("press 2 to update price");
            Console.WriteLine("press 3 to exit");
            int choice=int.Parse(Console.ReadLine());
            if (choice==1)
            {
                cafe.DisplayMenu();
            }
            else if (choice==2)
            {
                cafe.DisplayMenu();
                Console.WriteLine("enter item number:");
                int id=int.Parse(Console.ReadLine())-1;
                Console.WriteLine("enter new price:");
                int price=int.Parse(Console.ReadLine());

                cafe.UpdatePrice(id,price);
            }
            else
            {
                break;
            }
        }
    }
}

