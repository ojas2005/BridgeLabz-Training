public class AcademicRecordList
{
    private AcademicRecord start;
    public AcademicRecordList()
    {
        start=null;
    }
    public void insertAtStart(int id,string fullName,int yearOfBirth,char performance)
    {
        AcademicRecord record=new AcademicRecord(id,fullName,yearOfBirth,performance);
        record.link=start;
        start=record;
        Console.WriteLine("record inserted at start");
    }
    public void insertAtEnd(int id,string fullName,int yearOfBirth,char performance)
    {
        AcademicRecord record=new AcademicRecord(id,fullName,yearOfBirth,performance);
        if(start==null)
        {
            start=record;
            Console.WriteLine("record inserted");
            return;
        }
        AcademicRecord pointer=start;
        while(pointer.link!=null)
            pointer=pointer.link;
        pointer.link=record;
        Console.WriteLine("record inserted at end");
    }
    public void insertAtIndex(int id,string fullName,int yearOfBirth,char performance,int index)
    {
        if(index==1)
        {
            insertAtStart(id,fullName,yearOfBirth,performance);
            return;
        }
        AcademicRecord record=new AcademicRecord(id,fullName,yearOfBirth,performance);
        AcademicRecord pointer=start;
        int counter=1;
        while(pointer!=null&&counter<index-1)
        {
            pointer=pointer.link;
            counter++;
        }
        if(pointer==null)
        {
            Console.WriteLine("invalid index");
            return;
        }
        record.link=pointer.link;
        pointer.link=record;
        Console.WriteLine("record inserted at index "+index);
    }
    public void deleteById(int id)
    {
        if(start==null)
        {
            Console.WriteLine("list is empty");
            return;
        }
        if(start.id==id)
        {
            start=start.link;
            Console.WriteLine("record deleted");
            return;
        }
        AcademicRecord pointer=start;
        while(pointer.link!=null)
        {
            if(pointer.link.id==id)
            {
                pointer.link=pointer.link.link;
                Console.WriteLine("record deleted");
                return;
            }
            pointer=pointer.link;
        }
        Console.WriteLine("id not found");
    }
    public void findById(int id)
    {
        AcademicRecord pointer=start;
        while(pointer!=null)
        {
            if(pointer.id==id)
            {
                Console.WriteLine("record found - id: "+pointer.id+",name: "+pointer.fullName+",birth: "+pointer.yearOfBirth+",performance: "+pointer.performance);
                return;
            }
            pointer=pointer.link;
        }
        Console.WriteLine("record not found");
    }
    public void modifyPerformance(int id,char newPerformance)
    {
        AcademicRecord pointer=start;
        while(pointer!=null)
        {
            if(pointer.id==id)
            {
                pointer.performance=newPerformance;
                Console.WriteLine("performance updated to "+newPerformance);
                return;
            }
            pointer=pointer.link;
        }
        Console.WriteLine("id not found");
    }
    public void displayAll()
    {
        if(start==null)
        {
            Console.WriteLine("list is empty");
            return;
        }
        AcademicRecord pointer=start;
        Console.WriteLine("\nrecords");
        while(pointer!=null)
        {
            Console.WriteLine("id: "+pointer.id+" | name: "+pointer.fullName+" | birth: "+pointer.yearOfBirth+" | performance: "+pointer.performance);
            pointer=pointer.link;
        }
        Console.WriteLine();
    }
}
