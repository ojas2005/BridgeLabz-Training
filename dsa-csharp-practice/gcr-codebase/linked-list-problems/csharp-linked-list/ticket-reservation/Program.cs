class Program
{
    static void Main()
    {
        ReservationService srv=new ReservationService();
        srv.reserve(1,"arjun singh","avatar","a1","2:00");
        srv.reserve(2,"priya verma","avatar","a2","2:00");
        srv.reserve(3,"krishna kumar","inception","b1","3:30");
        srv.reserve(4,"neha gupta","inception","b2","3:30");
        srv.displayBookings();
        srv.displayTotal();
        srv.findByClient("priya verma");
        srv.findByFlick("avatar");
        srv.cancel(3);
        srv.displayBookings();
        srv.displayTotal();
    }
}
