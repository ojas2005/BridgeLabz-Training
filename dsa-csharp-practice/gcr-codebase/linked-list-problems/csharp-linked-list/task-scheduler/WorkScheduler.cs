public class WorkScheduler
{
    private WorkItem head;

    public WorkScheduler()
    {
        head=null;
    }

    public void insertAtStart(int itemId,string itemTitle,int level,string deadline)
    {
        WorkItem item=new WorkItem(itemId,itemTitle,level,deadline);
        if(head==null)
        {
            head=item;
            head.nextItem=head;
            Console.WriteLine("item added");
            return;
        }
        WorkItem last=head;
        while(last.nextItem!=head)
            last=last.nextItem;
        item.nextItem=head;
        last.nextItem=item;
        head=item;
        Console.WriteLine("item added at start");
    }

    public void insertAtEnd(int itemId,string itemTitle,int level,string deadline)
    {
        WorkItem item=new WorkItem(itemId,itemTitle,level,deadline);
        if(head==null)
        {
            head=item;
            head.nextItem=head;
            Console.WriteLine("item added");
            return;
        }
        WorkItem last=head;
        while(last.nextItem!=head)
            last=last.nextItem;
        last.nextItem=item;
        item.nextItem=head;
        Console.WriteLine("item added at end");
    }

    public void insertAtIndex(int itemId,string itemTitle,int level,string deadline,int index)
    {
        if(index==1)
        {
            insertAtStart(itemId,itemTitle,level,deadline);
            return;
        }
        WorkItem item=new WorkItem(itemId,itemTitle,level,deadline);
        WorkItem pointer=head;
        int counter=1;
        do
        {
            if(counter==index-1)
                break;
            pointer=pointer.nextItem;
            counter++;
        }while(pointer.nextItem!=head);
        item.nextItem=pointer.nextItem;
        pointer.nextItem=item;
        Console.WriteLine("item added at index "+index);
    }

    public void deleteItem(int itemId)
    {
        if(head==null)
        {
            Console.WriteLine("list is empty");
            return;
        }
        if(head.itemId==itemId)
        {
            if(head.nextItem==head)
            {
                head=null;
                Console.WriteLine("item removed");
                return;
            }
            WorkItem last=head;
            while(last.nextItem!=head)
                last=last.nextItem;
            last.nextItem=head.nextItem;
            head=head.nextItem;
            Console.WriteLine("item removed");
            return;
        }
        WorkItem pointer=head;
        do
        {
            if(pointer.nextItem.itemId==itemId)
            {
                pointer.nextItem=pointer.nextItem.nextItem;
                Console.WriteLine("item removed");
                return;
            }
            pointer=pointer.nextItem;
        }while(pointer.nextItem!=head);
        Console.WriteLine("item id not found");
    }

    public void displayCurrentAndAdvance()
    {
        if(head==null)
        {
            Console.WriteLine("list is empty");
            return;
        }
        Console.WriteLine("current item - id: "+head.itemId+",title: "+head.itemTitle+",level: "+head.level+",deadline: "+head.deadline);
        head=head.nextItem;
    }

    public void displayAll()
    {
        if(head==null)
        {
            Console.WriteLine("list is empty");
            return;
        }
        WorkItem pointer=head;
        Console.WriteLine("\nall items");
        do
        {
            Console.WriteLine("id: "+pointer.itemId+" | title: "+pointer.itemTitle+" | level: "+pointer.level+" | deadline: "+pointer.deadline);
            pointer=pointer.nextItem;
        }while(pointer!=head);
        Console.WriteLine();
    }

    public void findByLevel(int level)
    {
        if(head==null)
        {
            Console.WriteLine("list is empty");
            return;
        }
        WorkItem pointer=head;
        bool exists=false;
        do
        {
            if(pointer.level==level)
            {
                Console.WriteLine("id: "+pointer.itemId+" | title: "+pointer.itemTitle+" | level: "+pointer.level);
                exists=true;
            }
            pointer=pointer.nextItem;
        }while(pointer!=head);
        if(!exists)
            Console.WriteLine("no items with this level");
    }
}
