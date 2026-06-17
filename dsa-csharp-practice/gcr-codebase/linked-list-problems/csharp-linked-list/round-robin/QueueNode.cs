public class QueueNode
{
    public int id;
    public int duration;
    public int rank;
    public int remaining;
    public QueueNode nextNode;

    public QueueNode(int id,int duration,int rank)
    {
        this.id=id;
        this.duration=duration;
        this.rank=rank;
        this.remaining=duration;
        this.nextNode=null;
    }
}
