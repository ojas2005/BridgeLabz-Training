public interface ICheckout
{
    void AddCustomer(ICustomer customer);
    ICustomer RemoveCustomer();
    ICustomer PeekCustomer();
    int GetQueueLength();
    decimal ProcessCustomer();
    void DisplayQueue();
}