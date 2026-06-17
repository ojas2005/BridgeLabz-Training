using System;
using ParcelTrackingSystem.Services;

class Program
{
    static void Main()
    {
        ParcelTrackingService service=new ParcelTrackingService();

        service.CreateParcel("p1","Ojas","Pushpak");
        service.CreateParcel("p2","Pradeep","Prakhar");

        service.AddStageToParcel("p1","Picked Up","10 AM ","Mathura");
        service.AddStageToParcel("p1","In Transit","2 PM","New Delhi");
        service.AddCustomCheckpoint("p1","Warehouse Scan","5 PM","Meerut");

        service.DisplayParcelJourney("p1");
        service.DisplayParcelStats("p1");

        service.DisplayAllParcels();
    }
}
