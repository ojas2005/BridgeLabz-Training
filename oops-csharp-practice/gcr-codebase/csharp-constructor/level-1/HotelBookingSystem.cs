using System;
class HotelBookingSystem
    {
        string name;
        string roomType;
        int duration;
        public HotelBookingSystem(HotelBookingSystem previous)  //Copy constructor
        {
            this.name=previous.name;
            this.roomType=previous.roomType;
            this.duration=previous.duration;
        }
        public HotelBookingSystem() //Default Constructor
        {
            this.name="person1";
            this.roomType="non-ac";
            this.duration=2;
        }
        public HotelBookingSystem(string name, string roomType, int duration) //Parameterised Constructor
        {
            this.name=name;
            this.roomType=roomType;
            this.duration=duration;
        }

        public void Display() //Display method
        {
            Console.WriteLine($"{name} has booked this {roomType} room for {duration} days");
        }

    }
