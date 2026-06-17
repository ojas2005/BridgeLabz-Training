public class ReservationService
{
    private ReservationRecord start;
    private int booked;

    public ReservationService()
    {
        start=null;
        booked=0;
    }

    public void reserve(int rid,string client,string flick,string location,string instant)
    {
        ReservationRecord rec=new ReservationRecord(rid,client,flick,location,instant);
        if(start==null)
        {
            start=rec;
            start.nextRec=start;
            booked++;
            Console.WriteLine("reservation confirmed");
            return;
        }

        ReservationRecord last=start;
        while(last.nextRec!=start)
            last=last.nextRec;
        last.nextRec=rec;
        rec.nextRec=start;
        booked++;
        Console.WriteLine("reservation confirmed");
    }

    public void cancel(int rid)
    {
        if(start==null)
        {
            Console.WriteLine("no reservations");
            return;
        }

        if(start.rid==rid)
        {
            if(start.nextRec==start)
            {
                start=null;
                booked--;
                Console.WriteLine("reservation cancelled");
                return;
            }
            ReservationRecord last=start;
            while(last.nextRec!=start)
                last=last.nextRec;
            last.nextRec=start.nextRec;
            start=start.nextRec;
            booked--;
            Console.WriteLine("reservation cancelled");
            return;
        }

        ReservationRecord ptr=start;
        do
        {
            if(ptr.nextRec.rid==rid)
            {
                ptr.nextRec=ptr.nextRec.nextRec;
                booked--;
                Console.WriteLine("reservation cancelled");
                return;
            }
            ptr=ptr.nextRec;
        }while(ptr.nextRec!=start);

        Console.WriteLine("reservation not found");
    }

    public void displayBookings()
    {
        if(start==null)
        {
            Console.WriteLine("no bookings");
            return;
        }

        ReservationRecord ptr=start;
        Console.WriteLine("current reservations");
        do
        {
            Console.WriteLine("rid: "+ptr.rid+" client: "+ptr.client+" flick: "+ptr.flick+" location: "+ptr.location+" time: "+ptr.instant);
            ptr=ptr.nextRec;
        }while(ptr!=start);
        Console.WriteLine();
    }

    public void findByClient(string client)
    {
        if(start==null)
        {
            Console.WriteLine("no reservations");
            return;
        }

        ReservationRecord ptr=start;
        bool found=false;
        do
        {
            if(ptr.client.ToLower()==client.ToLower())
            {
                Console.WriteLine("rid: "+ptr.rid+" flick: "+ptr.flick+" location: "+ptr.location+" time: "+ptr.instant);
                found=true;
            }
            ptr=ptr.nextRec;
        }while(ptr!=start);
        if(!found)
            Console.WriteLine("no reservations for this client");
    }

    public void findByFlick(string flick)
    {
        if(start==null)
        {
            Console.WriteLine("no reservations");
            return;
        }

        ReservationRecord ptr=start;
        bool found=false;
        do
        {
            if(ptr.flick.ToLower()==flick.ToLower())
            {
                Console.WriteLine("client: "+ptr.client+" location: "+ptr.location+" time: "+ptr.instant);
                found=true;
            }
            ptr=ptr.nextRec;
        }while(ptr!=start);
        if(!found)
            Console.WriteLine("no reservations for this flick");
    }

    public void displayTotal()
    {
        Console.WriteLine("total reservations: "+booked);
    }
}
