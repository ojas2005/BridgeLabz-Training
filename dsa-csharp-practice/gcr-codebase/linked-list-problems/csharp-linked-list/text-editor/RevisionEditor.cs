public class RevisionEditor
{
    private RevisionNode start;
    private RevisionNode current;
    private int limit;
    private int count;

    public RevisionEditor(int limit)
    {
        start=null;
        current=null;
        count=0;
        this.limit=limit;
    }

    public void append(string text)
    {
        RevisionNode rev=new RevisionNode(text);
        if(start==null)
        {
            start=rev;
            current=rev;
            count=1;
            Console.WriteLine("text added: "+text);
            return;
        }
        if(current.nextRev!=null)
        {
            current.nextRev=null;
        }
        rev.prevRev=current;
        current.nextRev=rev;
        current=rev;
        count++;
        if(count>limit)
        {
            start=start.nextRev;
            start.prevRev=null;
            count--;
        }

        Console.WriteLine("text added: "+text);
    }

    public void goBack()
    {
        if(current==null||current.prevRev==null)
        {
            Console.WriteLine("cannot go back");
            return;
        }
        current=current.prevRev;
        Console.WriteLine("back - current text: "+current.data);
    }

    public void goForward()
    {
        if(current==null||current.nextRev==null)
        {
            Console.WriteLine("cannot go forward");
            return;
        }
        current=current.nextRev;
        Console.WriteLine("forward - current text: "+current.data);
    }

    public void showCurrent()
    {
        if(current==null)
        {
            Console.WriteLine("no text");
            return;
        }
        Console.WriteLine("current text: "+current.data);
    }

    public void showTimeline()
    {
        if(start==null)
        {
            Console.WriteLine("no timeline");
            return;
        }
        RevisionNode temp=start;
        Console.WriteLine("edit timeline");
        int seq=1;
        while(temp!=null)
        {
            string mark=(temp==current)?" --current text":"";
            Console.WriteLine(seq+". "+temp.data+mark);
            temp=temp.nextRev;
            seq++;
        }
        Console.WriteLine();
    }
}
