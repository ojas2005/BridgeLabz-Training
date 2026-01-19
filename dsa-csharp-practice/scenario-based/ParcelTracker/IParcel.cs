namespace ParcelTrackingSystem.Interfaces
{
    public interface IParcel
    {
        string ParcelId { get;}
        string Sender { get;}
        string Recipient { get;}
        bool IsLost { get;}

        void AddStage(string stage,string timestamp,string location);
        void DisplayJourney();
        int GetStageCount();
        void MarkAsLost();
    }
}
