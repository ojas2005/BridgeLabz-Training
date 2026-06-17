public class StockManagement
{
    private StockItem headItem;

    public StockManagement()
    {
        headItem=null;
    }

    public void insertAtStart(int code,string name,int available,double cost)
    {
        StockItem item=new StockItem(code,name,available,cost);
        item.nextItem=headItem;
        headItem=item;
        Console.WriteLine("item added at start");
    }

    public void insertAtEnd(int code,string name,int available,double cost)
    {
        StockItem item=new StockItem(code,name,available,cost);
        if(headItem==null)
        {
            headItem=item;
            Console.WriteLine("item added");
            return;
        }
        StockItem pointer=headItem;
        while(pointer.nextItem!=null)
            pointer=pointer.nextItem;
        pointer.nextItem=item;
        Console.WriteLine("item added at end");
    }

    public void insertAtIndex(int code,string name,int available,double cost,int index)
    {
        if(index==1)
        {
            insertAtStart(code,name,available,cost);
            return;
        }
        StockItem item=new StockItem(code,name,available,cost);
        StockItem pointer=headItem;
        int counter=1;
        while(pointer!=null&&counter<index-1)
        {
            pointer=pointer.nextItem;
            counter++;
        }
        if(pointer==null)
        {
            Console.WriteLine("invalid index");
            return;
        }
        item.nextItem=pointer.nextItem;
        pointer.nextItem=item;
        Console.WriteLine("item added at index "+index);
    }

    public void deleteByCode(int code)
    {
        if(headItem==null)
        {
            Console.WriteLine("list is empty");
            return;
        }
        if(headItem.code==code)
        {
            headItem=headItem.nextItem;
            Console.WriteLine("item removed");
            return;
        }
        StockItem pointer=headItem;
        while(pointer.nextItem!=null)
        {
            if(pointer.nextItem.code==code)
            {
                pointer.nextItem=pointer.nextItem.nextItem;
                Console.WriteLine("item removed");
                return;
            }
            pointer=pointer.nextItem;
        }
        Console.WriteLine("code not found");
    }

    public void updateAvailable(int code,int newCount)
    {
        StockItem pointer=headItem;
        while(pointer!=null)
        {
            if(pointer.code==code)
            {
                pointer.available=newCount;
                Console.WriteLine("available updated to "+newCount);
                return;
            }
            pointer=pointer.nextItem;
        }
        Console.WriteLine("code not found");
    }

    public void findByCode(int code)
    {
        StockItem pointer=headItem;
        while(pointer!=null)
        {
            if(pointer.code==code)
            {
                Console.WriteLine("item found - code: "+pointer.code+",name: "+pointer.name+",available: "+pointer.available+",cost: "+pointer.cost);
                return;
            }
            pointer=pointer.nextItem;
        }
        Console.WriteLine("code not found");
    }

    public void findByName(string name)
    {
        StockItem pointer=headItem;
        bool exists=false;
        while(pointer!=null)
        {
            if(pointer.name.ToLower()==name.ToLower())
            {
                Console.WriteLine("code: "+pointer.code+" | name: "+pointer.name+" | available: "+pointer.available+" | cost: "+pointer.cost);
                exists=true;
            }
            pointer=pointer.nextItem;
        }
        if(!exists)
            Console.WriteLine("item not found");
    }

    public void calculateTotalValue()
    {
        double sum=0;
        StockItem pointer=headItem;
        while(pointer!=null)
        {
            sum+=pointer.cost*pointer.available;
            pointer=pointer.nextItem;
        }
        Console.WriteLine("total inventory value: "+sum);
    }

    public void sortByName()
    {
        if(headItem==null||headItem.nextItem==null)
            return;
        bool changed;
        do
        {
            changed=false;
            StockItem pointer=headItem;
            while(pointer.nextItem!=null)
            {
                if(pointer.name.CompareTo(pointer.nextItem.name)>0)
                {
                    StockItem temp=pointer.nextItem;
                    pointer.nextItem=temp.nextItem;
                    temp.nextItem=pointer;
                    if(pointer==headItem)
                        headItem=temp;
                    changed=true;
                }
                pointer=pointer.nextItem;
            }
        }while(changed);
        Console.WriteLine("sorted by name");
    }

    public void sortByCost(bool ascending=true)
    {
        if(headItem==null||headItem.nextItem==null)
            return;
        bool changed;
        do
        {
            changed=false;
            StockItem pointer=headItem;
            while(pointer.nextItem!=null)
            {
                bool condition=ascending?(pointer.cost>pointer.nextItem.cost):(pointer.cost<pointer.nextItem.cost);
                if(condition)
                {
                    StockItem temp=pointer.nextItem;
                    pointer.nextItem=temp.nextItem;
                    temp.nextItem=pointer;
                    if(pointer==headItem)
                        headItem=temp;
                    changed=true;
                }
                pointer=pointer.nextItem;
            }
        }while(changed);
        Console.WriteLine("sorted by cost");
    }

    public void displayAll()
    {
        if(headItem==null)
        {
            Console.WriteLine("inventory is empty");
            return;
        }
        StockItem pointer=headItem;
        Console.WriteLine("\ninventory items");
        while(pointer!=null)
        {
            Console.WriteLine("code: "+pointer.code+" | name: "+pointer.name+" | available: "+pointer.available+" | cost: "+pointer.cost);
            pointer=pointer.nextItem;
        }
        Console.WriteLine();
    }
}
