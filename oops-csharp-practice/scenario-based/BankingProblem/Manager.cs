class Manager
{
    private string managerId = "manager1";
    private string password = "manager1password";
    int numberOfUsers = 10000;
    User[] users = new User[10000];
    int userCount = 0;
    public bool ManagerAuthentication(string id,string pass)
    {
        if (id==managerId&&pass==password)
        {
            Console.WriteLine("Authentication Successful");
            return true;
        }
        else
        {
            Console.WriteLine("Authentication failed");
            return false;
        }
    }
    public void AddNewUser(int accountNumber,int pin,double balance)
    {
        if(userCount<users.Length)
        {
            users[userCount] = new User(accountNumber,pin,balance);
            userCount++;
            Console.WriteLine("New user added");
        }
        else
        {
            Console.WriteLine("User limit reached");
        }
    }
    public void UpdateBalance(int accountNumber,double newBalance)
    {
        for (int i=0;i<userCount;i++)
        {
            if (users[i].accountNumber == accountNumber)
            {
                users[i].balance = newBalance;
                Console.WriteLine("Balance updated");
                return;
            }
        }
        Console.WriteLine("User not found");
    }
    public void DeleteUser(int accountNumber)
    {
        for (int i=0;i<userCount;i++)
        {
            if (users[i].accountNumber==accountNumber)
            {
                for (int j=i;j<userCount-1;j++)
                {
                    users[j]=users[j+1];
                }
                userCount--;
                Console.WriteLine("Deleted the user");
                return;
            }
        }
        Console.WriteLine("Can not find any user with this account number");
    }
    public void ListUsers()
    {
        if(userCount==0)
        {
            Console.WriteLine("No user has been added yet");
        }
        else{
        Console.WriteLine("list of all users");
        for (int i = 0;i<userCount;i++)
        {
            Console.WriteLine("account Number: "+users[i].accountNumber+"  balance: " + users[i].balance);
        }
        }
    }
}
