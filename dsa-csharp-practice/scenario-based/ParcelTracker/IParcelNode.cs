namespace ParcelTracker.Interfaces
{
	public interface IParcelNode
	{
		string getStage();
		string getTimestamp();
		string getLocation();
		IParcelNode getNext();
		void setNext(IParcelNode node);
	}
}
