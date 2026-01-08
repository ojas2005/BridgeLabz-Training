public class DigitalLibrary
{
    private VolumeEntry head;
    private int count;

    public DigitalLibrary()
    {
        head=null;
        count=0;
    }

    public void insertAtStart(int volumeId,string title,string writer,string category,bool inStock)
    {
        VolumeEntry entry=new VolumeEntry(volumeId,title,writer,category,inStock);
        if(head==null)
        {
            head=entry;
            count++;
            Console.WriteLine("volume added");
            return;
        }
        entry.nextLink=head;
        head.prevLink=entry;
        head=entry;
        count++;
        Console.WriteLine("volume added at start");
    }

    public void insertAtEnd(int volumeId,string title,string writer,string category,bool inStock)
    {
        VolumeEntry entry=new VolumeEntry(volumeId,title,writer,category,inStock);
        if(head==null)
        {
            head=entry;
            count++;
            Console.WriteLine("volume added");
            return;
        }
        VolumeEntry pointer=head;
        while(pointer.nextLink!=null)
            pointer=pointer.nextLink;
        pointer.nextLink=entry;
        entry.prevLink=pointer;
        count++;
        Console.WriteLine("volume added at end");
    }

    public void insertAtIndex(int volumeId,string title,string writer,string category,bool inStock,int index)
    {
        if(index==1)
        {
            insertAtStart(volumeId,title,writer,category,inStock);
            return;
        }
        VolumeEntry entry=new VolumeEntry(volumeId,title,writer,category,inStock);
        VolumeEntry pointer=head;
        int counter=1;
        while(pointer!=null&&counter<index-1)
        {
            pointer=pointer.nextLink;
            counter++;
        }
        if(pointer==null)
        {
            Console.WriteLine("invalid index");
            return;
        }
        entry.nextLink=pointer.nextLink;
        entry.prevLink=pointer;
        if(pointer.nextLink!=null)
            pointer.nextLink.prevLink=entry;
        pointer.nextLink=entry;
        count++;
        Console.WriteLine("volume added at index "+index);
    }

    public void deleteById(int volumeId)
    {
        if(head==null)
        {
            Console.WriteLine("library is empty");
            return;
        }
        if(head.volumeId==volumeId)
        {
            head=head.nextLink;
            if(head!=null)
                head.prevLink=null;
            count--;
            Console.WriteLine("volume removed");
            return;
        }
        VolumeEntry pointer=head;
        while(pointer!=null)
        {
            if(pointer.volumeId==volumeId)
            {
                if(pointer.prevLink!=null)
                    pointer.prevLink.nextLink=pointer.nextLink;
                if(pointer.nextLink!=null)
                    pointer.nextLink.prevLink=pointer.prevLink;
                count--;
                Console.WriteLine("volume removed");
                return;
            }
            pointer=pointer.nextLink;
        }
        Console.WriteLine("volume id not found");
    }

    public void findByTitle(string title)
    {
        VolumeEntry pointer=head;
        while(pointer!=null)
        {
            if(pointer.title.ToLower()==title.ToLower())
            {
                Console.WriteLine("id: "+pointer.volumeId+" | title: "+pointer.title+" | writer: "+pointer.writer+" | category: "+pointer.category+" | in stock: "+pointer.inStock);
                return;
            }
            pointer=pointer.nextLink;
        }
        Console.WriteLine("volume not found");
    }

    public void findByWriter(string writer)
    {
        VolumeEntry pointer=head;
        bool exists=false;
        while(pointer!=null)
        {
            if(pointer.writer.ToLower()==writer.ToLower())
            {
                Console.WriteLine("title: "+pointer.title+" | category: "+pointer.category+" | in stock: "+pointer.inStock);
                exists=true;
            }
            pointer=pointer.nextLink;
        }
        if(!exists)
            Console.WriteLine("no volumes by this writer");
    }

    public void updateStock(int volumeId,bool newStatus)
    {
        VolumeEntry pointer=head;
        while(pointer!=null)
        {
            if(pointer.volumeId==volumeId)
            {
                pointer.inStock=newStatus;
                Console.WriteLine("stock status updated to "+newStatus);
                return;
            }
            pointer=pointer.nextLink;
        }
        Console.WriteLine("volume id not found");
    }

    public void displayForward()
    {
        if(head==null)
        {
            Console.WriteLine("library is empty");
            return;
        }
        VolumeEntry pointer=head;
        Console.WriteLine("\nvolumes forward");
        while(pointer!=null)
        {
            Console.WriteLine("id: "+pointer.volumeId+" | "+pointer.title+" | "+pointer.writer+" | "+pointer.category+" | in stock: "+pointer.inStock);
            pointer=pointer.nextLink;
        }
        Console.WriteLine();
    }

    public void displayBackward()
    {
        if(head==null)
        {
            Console.WriteLine("library is empty");
            return;
        }
        VolumeEntry pointer=head;
        while(pointer.nextLink!=null)
            pointer=pointer.nextLink;
        Console.WriteLine("\nvolumes backward");
        while(pointer!=null)
        {
            Console.WriteLine("id: "+pointer.volumeId+" | "+pointer.title+" | "+pointer.writer+" | "+pointer.category+" | in stock: "+pointer.inStock);
            pointer=pointer.prevLink;
        }
        Console.WriteLine();
    }

    public void displayCount()
    {
        Console.WriteLine("total volumes in library: "+count);
    }
}
