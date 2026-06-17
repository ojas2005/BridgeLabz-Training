class Program
{
    static void Main()
    {
        DigitalLibrary lib=new DigitalLibrary();

        lib.insertAtEnd(1,"harry potter","j.k. rowling","fantasy",true);
        lib.insertAtEnd(2,"1984","george orwell","dystopian",true);
        lib.insertAtEnd(3,"pride and prejudice","jane austen","romance",false);
        lib.insertAtStart(4,"the hobbit","j.r.r. tolkien","fantasy",true);

        lib.displayForward();
        lib.displayBackward();
        lib.displayCount();

        lib.findByWriter("j.k. rowling");
        lib.updateStock(3,true);
        lib.deleteById(2);

        lib.displayForward();
        lib.displayCount();
    }
}
