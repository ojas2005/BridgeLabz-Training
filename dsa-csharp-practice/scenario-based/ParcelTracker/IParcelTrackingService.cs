using ParcelTrackingSystem.Interfaces;

namespace ParcelTrackingSystem.Services
{
    public interface IParcelTrackingService
    {
        void CreateParcel(string parcelId,string sender,string recipient);
        IParcel? FindParcel(string parcelId);
        void AddStageToParcel(string parcelId,string stage,string timestamp,string location);
        void AddCustomCheckpoint(string parcelId,string checkpointName,string timestamp,string location);
        void MarkParcelAsLost(string parcelId);
        void TrackParcelForward(string parcelId);
        void DisplayParcelJourney(string parcelId);
        void DisplayAllParcels();
        void DisplayParcelStats(string parcelId);
    }
}
