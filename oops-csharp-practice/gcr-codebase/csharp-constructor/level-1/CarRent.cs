using System;
class CarRent
    {
        //initialising attributes
        string buyer;
        string nameOfCar;
        int forDuration;

        //default constructor
        public CarRent()
        {
            this.forDuration=0;
            this.buyer="Ajay";
            this.nameOfCar="Audi Q5";
        }
        //parameterized constructor
        public CarRent(string buyer,string nameOfCar,int forDuration)
        {
            this.buyer=buyer;
            this.nameOfCar=nameOfCar;
            this.forDuration=forDuration;
        }

        //to calculate price
        public void price()
        {
            int totalPrice=forDuration*5;
            Console.WriteLine($"the total price is {totalPrice}");
        }

    }

