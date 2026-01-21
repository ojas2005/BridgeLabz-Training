class Program
{
    static void Main()
    {
        ICheckout checkout = new CheckoutCounter();
        CheckoutCounter counter = (CheckoutCounter)checkout;

        while (true)
        {
            Console.WriteLine("\nmenu");
            Console.WriteLine("press 1 to add inventory item");
            Console.WriteLine("press 2 to add customer");
            Console.WriteLine("press 3 to process next customer");
            Console.WriteLine("press 4 to display queue");
            Console.WriteLine("press 5 to display inventory");
            Console.WriteLine("press 6 to exit");
            Console.Write("choose option: ");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.Write("enter item name: ");
                string name = Console.ReadLine();

                Console.Write("enter price: ");
                decimal price = decimal.Parse(Console.ReadLine());

                Console.Write("enter stock: ");
                int stock = int.Parse(Console.ReadLine());

                counter.AddItemToInventory(name, new Item(name, price, stock));
                Console.WriteLine("item added to inventory");
            }
            else if (choice == 2)
            {
                Console.Write("enter customer name: ");
                string cname = Console.ReadLine();
                ICustomer customer = new Customer(cname);

                while (true)
                {
                    Console.Write("enter item name (or done): ");
                    string itemName = Console.ReadLine().ToLower();
                    if (itemName == "done")
                        break;

                    Console.Write("enter quantity: ");
                    int qty = int.Parse(Console.ReadLine());

                    customer.AddItem(new CartItem(counter.GetItem(itemName), qty));
                }

                checkout.AddCustomer(customer);
            }
            else if (choice == 3)
            {
                checkout.ProcessCustomer();
            }
            else if (choice == 4)
            {
                checkout.DisplayQueue();
            }
            else if (choice == 5)
            {
                counter.DisplayInventory();
            }
            else if (choice == 6)
            {
                Console.WriteLine("exiting system");
                break;
            }
        }
    }
}
