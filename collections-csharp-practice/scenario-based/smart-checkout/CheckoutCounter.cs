public class CheckoutCounter : ICheckout
{
    private Queue<ICustomer> customerQueue;
    private Dictionary<string, IItem> inventory; 

    public CheckoutCounter()
    {
        customerQueue = new Queue<ICustomer>();
        inventory = new Dictionary<string, IItem>();
    }
    public void AddItemToInventory(string itemName, IItem item)
    {
        inventory[itemName] = item;
    }
    public decimal GetItemPrice(string itemName)
    {
        if (inventory.ContainsKey(itemName))
        {
            return inventory[itemName].GetPrice();
        }
        throw new Exception($"item '{itemName}' not found in inventory");
    }

    public IItem GetItem(string itemName)
    {
        if (inventory.ContainsKey(itemName))
        {
            return inventory[itemName];
        }
        throw new Exception($"item '{itemName}' not found");
    }

    public void AddCustomer(ICustomer customer)
    {
        customerQueue.Enqueue(customer);
        Console.WriteLine($"{customer.GetCustomerName()} added to queue. queue length:- {customerQueue.Count}");
    }

    public ICustomer RemoveCustomer()
    {
        if (customerQueue.Count > 0)
        {
            return customerQueue.Dequeue();
        }
        throw new Exception("queue is empty");
    }
    public ICustomer PeekCustomer()
    {
        if (customerQueue.Count > 0)
        {
            return customerQueue.Peek();
        }
        throw new Exception("queue is empty");
    }

    public int GetQueueLength()
    {
        return customerQueue.Count;
    }
    public decimal ProcessCustomer()
    {
        if (customerQueue.Count == 0)
        {
            throw new Exception("no customer to process");
        }

        ICustomer customer = RemoveCustomer();
        decimal total = 0;

        Console.WriteLine($"\nProcessing: {customer.GetCustomerName()}");
        
        foreach (CartItem cartItem in customer.GetItems())
        {
            if (cartItem.Item.IsAvailable(cartItem.Quantity))
            {
                cartItem.Item.UpdateStock(cartItem.Quantity);
                decimal subtotal = cartItem.GetSubtotal();
                total += subtotal;
                Console.WriteLine($"{cartItem.Item.GetName()} x {cartItem.Quantity} = {subtotal}rs");
            }
            else
            {
                Console.WriteLine($"{cartItem.Item.GetName()} - insufficient stock");
            }
        }

        Console.WriteLine($"total Bill: {total}rs");
        return total;
    }

    public void DisplayQueue()
    {
        Console.WriteLine("\nCheckout Queue");
        if (customerQueue.Count == 0)
        {
            Console.WriteLine("queue is empty");
            return;
        }

        int position = 1;
        foreach (ICustomer customer in customerQueue)
        {
            Console.WriteLine($"{position}. {customer}");
            position++;
        }
    }
    public void DisplayInventory()
    {
        Console.WriteLine("\nInventory");
        foreach (var item in inventory)
        {
            Console.WriteLine($"{item.Value}");
        }
    }
}