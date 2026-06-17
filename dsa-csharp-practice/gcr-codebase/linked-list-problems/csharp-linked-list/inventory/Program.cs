class Program
{
    static void Main()
    {
        StockManagement stock=new StockManagement();

        stock.insertAtEnd(1,"laptop",5,50000);
        stock.insertAtEnd(2,"phone",10,20000);
        stock.insertAtEnd(3,"tablet",7,15000);
        stock.insertAtEnd(4,"keyboard",20,2000);

        stock.displayAll();
        stock.calculateTotalValue();

        stock.findByName("phone");
        stock.updateAvailable(2,8);
        stock.sortByCost(true);
        stock.displayAll();

        stock.deleteByCode(4);
        stock.displayAll();
    }
}
