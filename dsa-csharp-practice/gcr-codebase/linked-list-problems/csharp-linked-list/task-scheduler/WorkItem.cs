public class WorkItem
{
    public int itemId;
    public string itemTitle;
    public int level;
    public string deadline;
    public WorkItem nextItem;

    public WorkItem(int itemId,string itemTitle,int level,string deadline)
    {
        this.itemId=itemId;
        this.itemTitle=itemTitle;
        this.level=level;
        this.deadline=deadline;
        this.nextItem=null;
    }
}
