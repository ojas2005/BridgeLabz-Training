public class VolumeEntry
{
    public int volumeId;
    public string title;
    public string writer;
    public string category;
    public bool inStock;
    public VolumeEntry nextLink;
    public VolumeEntry prevLink;

    public VolumeEntry(int volumeId,string title,string writer,string category,bool inStock)
    {
        this.volumeId=volumeId;
        this.title=title;
        this.writer=writer;
        this.category=category;
        this.inStock=inStock;
        this.nextLink=null;
        this.prevLink=null;
    }
}
