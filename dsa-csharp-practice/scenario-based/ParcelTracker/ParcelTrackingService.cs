using System;
using ParcelTrackingSystem.Interfaces;
using ParcelTrackingSystem.Models;

namespace ParcelTrackingSystem.Services
{
    public class ParcelTrackingService : IParcelTrackingService
    {
        private IParcel[] parcels=new IParcel[50];
        private int count=0;

        public void CreateParcel(string parcelId,string sender,string recipient)
        {
            if (count<parcels.Length)
            {
                parcels[count++]=new Parcel(parcelId,sender,recipient);
                Console.WriteLine($"parcel {parcelId} created");
            }
        }
        public IParcel? FindParcel(string parcelId)
        {
            for (int i=0;i<count;i++)
            {
                if (parcels[i].ParcelId == parcelId)
                {
                    return parcels[i];
                }
            }
            return null;
        }

        public void AddStageToParcel(string parcelId,string stage,string timestamp,string location)
        {
            IParcel? parcel=FindParcel(parcelId);
            if (parcel != null)
            {
                parcel.AddStage(stage,timestamp,location);
            }
        }

        public void AddCustomCheckpoint(string parcelId,string checkpointName,string timestamp,string location)
        {
            AddStageToParcel(parcelId,checkpointName,timestamp,location);
        }

        public void MarkParcelAsLost(string parcelId)
        {
            IParcel? parcel=FindParcel(parcelId);
            parcel?.MarkAsLost();
        }

        public void TrackParcelForward(string parcelId)
        {
            Console.WriteLine($"tracking parcel {parcelId} forward");
        }

        public void DisplayParcelJourney(string parcelId)
        {
            IParcel? parcel=FindParcel(parcelId);
            parcel?.DisplayJourney();
        }

        public void DisplayAllParcels()
        {
            Console.WriteLine("\nall Parcels:");
            for (int i=0;i<count;i++)
            {
                Console.WriteLine($"{parcels[i].ParcelId} Lost: {parcels[i].IsLost}");
            }
        }

        public void DisplayParcelStats(string parcelId)
        {
            IParcel? parcel=FindParcel(parcelId);
            if (parcel != null)
            {
                Console.WriteLine($"\nstats for {parcelId}:");
                Console.WriteLine($"stages: {parcel.GetStageCount()}");
                Console.WriteLine($"lost: {parcel.IsLost}");
            }
        }
    }
}
