using ParcelTrackingSystem.Interfaces;

namespace ParcelTrackingSystem.Models
{
    public class Parcel : IParcel
    {
        private string[] stages=new string[20];
        private int stageCount=0;

        public string ParcelId { get;private set;}
        public string Sender { get;private set;}
        public string Recipient { get;private set;}
        public bool IsLost { get;private set;}

        public Parcel(string parcelId,string sender,string recipient)
        {
            ParcelId=parcelId;
            Sender=sender;
            Recipient=recipient;
            IsLost=false;
        }

        public void AddStage(string stage,string timestamp, string location)
        {
            if (stageCount<stages.Length)
            {
                stages[stageCount++]=$"{timestamp}-{stage} at {location}";
            }
        }

        public void DisplayJourney()
        {
            System.Console.WriteLine($"Order summary of {ParcelId}:");
            for (int i=0;i<stageCount;i++)
            {
                System.Console.WriteLine($"{stages[i]}");
            }
        }

        public int GetStageCount()
        {
            return stageCount;
        }

        public void MarkAsLost()
        {
            IsLost=true;
        }
    }
}
