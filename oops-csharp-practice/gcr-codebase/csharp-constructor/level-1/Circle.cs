using System;

class Circle
{

    private double radius; //initialised radius attribute
    public Circle() : this(29.0) 
    {
        Console.WriteLine("Default area"); //default constructor chaining
    }
    public Circle(double radius) //parameterised constructor
    {
       this.radius = radius;
    }
    public double CircumferenceOfCircle()
    {
        double circ = 2*Math.PI*radius;
        return circ;
    }
    public double AreaOfCircle()
    {
        double area = Math.PI*radius*radius;
        return area;
    }
    public void Display()
    {
        Console.WriteLine($"radius of the circle is {radius}" );
        double ar = AreaOfCircle();
        Console.WriteLine($"area of the circle is {ar}");
        double cir = CircumferenceOfCircle();
        Console.WriteLine($"circumference of the circle is {cir}" );
    }
}