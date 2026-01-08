public class StockItem
{
    public int code;
    public string name;
    public int available;
    public double cost;
    public StockItem nextItem;

    public StockItem(int code,string name,int available,double cost)
    {
        this.code=code;
        this.name=name;
        this.available=available;
        this.cost=cost;
        this.nextItem=null;
    }
}
