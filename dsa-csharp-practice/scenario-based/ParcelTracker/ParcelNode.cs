using ParcelTracker.Interfaces;

namespace ParcelTracker.Models
{
	public class ParcelNode:IParcelNode
	{
		public string stage;
		public string timestamp;
		public string location;
		public ParcelNode next;

		public ParcelNode(string stage,string timestamp,string location)
		{
			this.stage=stage;
			this.timestamp=timestamp;
			this.location=location;
			this.next=null;
		}

		public string getStage()
		{
			return stage;
		}

		public string getTimestamp()
		{
			return timestamp;
		}

		public string getLocation()
		{
			return location;
		}

		public IParcelNode getNext()
		{
			return next;
		}

		public void setNext(IParcelNode node)
		{
			next=(ParcelNode)node;
		}
	}
}
