class Program
{
    static void Main()
    {
        WorkScheduler scheduler=new WorkScheduler();

        scheduler.insertAtEnd(1,"email reply",1,"today");
        scheduler.insertAtEnd(2,"code review",2,"tomorrow");
        scheduler.insertAtEnd(3,"meeting prep",3,"next week");
        scheduler.insertAtStart(4,"urgent fix",1,"today");

        scheduler.displayAll();
        scheduler.displayCurrentAndAdvance();
        scheduler.displayCurrentAndAdvance();

        scheduler.findByLevel(1);
        scheduler.deleteItem(3);

        scheduler.displayAll();
    }
}
