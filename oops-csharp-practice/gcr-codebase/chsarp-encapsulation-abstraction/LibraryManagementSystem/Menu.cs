using System;

namespace LibraryApp
{
    internal class Menu
    {
        LibraryItem[] items = new LibraryItem[3];
        int idx = 0;

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("library management");
                Console.WriteLine("1. add book");
                Console.WriteLine("2. add magazine");
                Console.WriteLine("3. add dvd");
                Console.WriteLine("4. show items");
                Console.WriteLine("5. reserve item");
                Console.WriteLine("6. exit");
                int c = Convert.ToInt32(Console.ReadLine());

                switch (c)
                {
                    case 1: AddNew(new Book()); break;
                    case 2: AddNew(new Magazine()); break;
                    case 3: AddNew(new DVD()); break;
                    case 4: PrintAll(); break;
                    case 5: ReserveOne(); break;
                    case 6: return;
                }
            }
        }

        void AddNew(LibraryItem item)
        {
            if (idx >= items.Length) return;

            Console.Write("enter id: ");
            item.SetId(Convert.ToInt32(Console.ReadLine()));

            Console.Write("enter title: ");
            item.SetTitle(Console.ReadLine());

            Console.Write("enter author: ");
            item.SetAuthor(Console.ReadLine());

            items[idx++] = item;
        }

        void PrintAll()
        {
            for (int i = 0; i < idx; i++)
            {
                items[i].PrintDetails();
                Console.WriteLine("loan days: " + items[i].GetDays());
            }
        }

        void ReserveOne()
        {
            Console.Write("enter index: ");
            int i = Convert.ToInt32(Console.ReadLine());

            if (items[i] is IReservable r)
                r.Reserve();
        }
    }
}
