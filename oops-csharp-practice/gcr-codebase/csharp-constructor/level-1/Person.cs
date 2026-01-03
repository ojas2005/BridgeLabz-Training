using System;
class Person
    {
        string name;
        int age;
        public Person(Person previous) //copy constructor
        {
            this.name=previous.name;
            this.age=previous.age;
        }
        public Person() //default constructor
        {
            this.name = "Xyx";
            this.age = 20;
        }
        public Person(string name, int age) //parameterised constructor
        {
            this.name=name;
            this.age=age;
        }
        public void Display()
        {
            Console.WriteLine($"The name of this person is {name} and he is {age} years old");
        }
    }
