class Program
{
    static void Main()
    {
        AcademicRecordList list=new AcademicRecordList();
        list.insertAtStart(101,"arjun",20,'A');
        list.insertAtEnd(102,"priya",19,'B');
        list.insertAtEnd(103,"deepak",21,'A');
        list.insertAtIndex(104,"neha",20,'C',2);
        list.displayAll();
        list.findById(102);
        list.modifyPerformance(102,'A');
        list.deleteById(104);
        list.displayAll();
    }
}
