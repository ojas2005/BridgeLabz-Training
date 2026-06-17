class User
{
    Cafeteria cafe;

    public User(Cafeteria cafe)
    {
        this.cafe=cafe;
    }
    public void UserMenu()
    {
        double totalAmount=0;
        while (true)
        {
            Console.WriteLine("user menu");
            Console.WriteLine(" ");
            Console.WriteLine("press 1 to view menu");
            Console.WriteLine("press 2 to order item");
            Console.WriteLine("press 3 to exit");
            int choice=int.Parse(Console.ReadLine());

            if(choice==1)
            {
                cafe.DisplayMenu();
            }
            else if(choice==2)
            {
                cafe.DisplayMenu();
                Console.WriteLine("enter item number:");
                int id=int.Parse(Console.ReadLine())-1;
                Console.WriteLine("enter quantity:");
                int qty=int.Parse(Console.ReadLine());
                double bill=cafe.TotalBill(id,qty);
                totalAmount+=bill;
                Console.WriteLine($"you have ordered {qty} {cafe.items[id].name}");
            }
            else
            {
                Console.WriteLine($"Total Bill: Rs {totalAmount}");
                break;
            }
        }
    }
}

