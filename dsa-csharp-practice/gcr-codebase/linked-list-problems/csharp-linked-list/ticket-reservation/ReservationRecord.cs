public class ReservationRecord
{
    public int rid;
    public string client;
    public string flick;
    public string location;
    public string instant;
    public ReservationRecord nextRec;

    public ReservationRecord(int rid,string client,string flick,string location,string instant)
    {
        this.rid=rid;
        this.client=client;
        this.flick=flick;
        this.location=location;
        this.instant=instant;
        this.nextRec=null;
    }
}
