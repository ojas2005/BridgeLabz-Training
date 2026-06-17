using System;
class CafeteriaMenuApp{
    void DisplayMenu(string[] str,string[] price)
    {
        Console.WriteLine("\n---------------------Menu------------------");
        for(int i = 0;i<str.Length;i++)
        {
            Console.WriteLine($" {i+1}. {str[i]} price - {price[i]} rs");
        }
        Console.WriteLine("");
    }
    void GetItemByIndex(int index,int quantity, string[] str)
    {
        index = index-1;
        for(int i = 0;i<str.Length;i++)
        {
            if(i==index)
            {
                Console.WriteLine($"Your order of {quantity} {str[i]} has been placed");
            }
        }   
        Console.WriteLine(""); 
    }
    int amountBill(int index,int quantity, string[] price)
    {
        index = index-1;
        int amount=0;
        for(int i = 0;i<price.Length;i++)
        {
            if(i==index)
            {
                amount+=int.Parse(price[i])*quantity;
            }
        }
        return amount;
    }

    static void Main()
    {
        string[] str = {"Aloo pantha","Veg Momos","Paneer Roll","Sandwich","Burger","Cheese Pizza Regular","Gravy Momos","Pastry","Cold coffe","Hot tea"};
        string[] price = {"45","60","85","40","40","199","120","40","60","20"};
        while(true)
        {
        Console.WriteLine("\n----------------App Menu----------------");
        Console.WriteLine("What services do you want to use?");
        Console.WriteLine("Press 1 to display the menu");
        Console.WriteLine("Press 2 to select an item to order");
        
        Console.WriteLine("Press 3 to exit the menu");
        Console.WriteLine("");
        int choice = int.Parse(Console.ReadLine());
        CafeteriaMenuApp dis = new CafeteriaMenuApp();
        int totalAmount=0;
        
            switch(choice)
            {
                case 1:
                    dis.DisplayMenu(str,price);
                    break;
                case 2:
                    Console.WriteLine("Enter the item's index that you want to order.");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter quantity");
                    int quantity = int.Parse(Console.ReadLine());
                    dis.GetItemByIndex(id,quantity,str);
                    totalAmount+=dis.amountBill(id,quantity,price);
                    while(true)
                    {
                        Console.WriteLine("Do you want to order more items? Press 1 for yes,2 for no");
                        int yn =  int.Parse(Console.ReadLine());
                        if(yn==1)
                        {
                            Console.WriteLine("Enter the item's index that you want to order.");
                            id = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter quantity");
                            quantity = int.Parse(Console.ReadLine());
                            dis.GetItemByIndex(id,quantity,str);
                            totalAmount+=dis.amountBill(id,quantity,price);
                        }
                        else{
                            break;
                        }
                    }
                    Console.WriteLine("");
                    Console.WriteLine($"Total amount to be paid is : {totalAmount}rs");

                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
                    
            }

        }
    }
}