public class RevisionNode
{
    public string data;
    public RevisionNode nextRev;
    public RevisionNode prevRev;

    public RevisionNode(string data)
    {
        this.data=data;
        this.nextRev=null;
        this.prevRev=null;
    }
}
