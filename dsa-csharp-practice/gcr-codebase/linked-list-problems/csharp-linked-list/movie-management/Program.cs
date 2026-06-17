class Program
{
    static void Main()
    {
        FilmCollection collection=new FilmCollection();

        collection.insertAtEnd("inception","christopher nolan",2010,8.8);
        collection.insertAtEnd("dark knight","christopher nolan",2008,9.0);
        collection.insertAtEnd("interstellar","christopher nolan",2014,8.6);
        collection.insertAtBegin("titanic","james cameron",1997,7.9);

        collection.displayInOrder();
        collection.displayInReverse();

        collection.findByCreator("christopher nolan");
        collection.modifyScore("inception",9.0);
        collection.deleteByName("titanic");

        collection.displayInOrder();
    }
}
