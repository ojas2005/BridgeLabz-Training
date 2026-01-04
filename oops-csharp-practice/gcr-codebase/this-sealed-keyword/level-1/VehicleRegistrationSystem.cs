using System;
class VehicleManagementSystem
    {
        static void Main(string[] args)
        {
            Vehicle v1=new Vehicle("Aman","bike",2022);

            if (v1 is Vehicle)
            {
                v1.Show();
            }

            Vehicle.UpdateRegistrationFee(2000);
        }
    }
    public class Vehicle
    {
        public static int RegistrationFee=1500;
        public readonly int RegistrationNumber;
        string owner;
        string type;
        public Vehicle(string owner,string type,int RegistrationNumber)
        {
            this.owner=owner;
            this.type=type;
            this.RegistrationNumber=RegistrationNumber;
        }
        public static void UpdateRegistrationFee(int fee)
        {
            RegistrationFee=fee;
            Console.WriteLine($"registration fee is {RegistrationFee}");
        }
        public void Show()
        {
            Console.WriteLine($"owner name is {owner}");
            Console.WriteLine($"vehicle type is {type}");
            Console.WriteLine($"vehicle number is {RegistrationNumber}");
        }
    }
