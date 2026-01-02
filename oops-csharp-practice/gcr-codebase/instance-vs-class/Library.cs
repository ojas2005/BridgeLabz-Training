using System;
class Libaray
    {
        //created the atributes
        string title;
        string author;
        double price;
        bool avaliable;
        //default con
        public Libaray()
        {
            this.title = "the heat of Lava";
            this.author = "Mount ain";
            this.price = 0.0;
            this.avaliable = false;
        }
        //parameter con
        public Libaray(string title, string author, double price, bool avaliable)
        {
            this.title = title;
            this.author = author;
            this.price = price;
            this.avaliable = avaliable;
        }
        // method to find if it is avalible
        public void IsItAvaliable()
        {
            if (avaliable)
            {
                this.avaliable = false;
                Console.WriteLine("it is avalable");
            }
            else
            {
                Console.WriteLine("it is not avalible");
            }
        }

    }


