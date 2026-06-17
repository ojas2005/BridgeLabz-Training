using HealthClinic.Exception;
using HealthClinic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.Menu
{
    public sealed class BillingMenu
    {
        private readonly IBillingUtility _util;

        public BillingMenu(IBillingUtility util) => _util = util;

        // HELPER REPORT
        public void RevenueReport()
        {
            Console.Write("Start date (yyyy-mm-dd): ");
            var s = DateTime.Parse(Console.ReadLine() ?? "").Date;
            Console.Write("End date (yyyy-mm-dd): ");
            var e = DateTime.Parse(Console.ReadLine() ?? "").Date;

            var lines = _util.RevenueReportLines(s, e);
            if (lines.Count == 0) { Console.WriteLine("No revenue."); return; }
            foreach (var line in lines) Console.WriteLine(line);
        }

        // ACTION GENERATE
        private void Generate()
        {
            Console.Write("Visit ID: ");
            var id = int.Parse(Console.ReadLine() ?? "0");
            _util.GenerateBill(id);
            Console.WriteLine("Bill generated.");
        }

        // ACTION ADD ITEM
        private void AddItem()
        {
            Console.Write("Bill ID: ");
            var billId = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Item name: ");
            var name = Console.ReadLine() ?? "";
            Console.Write("Amount: ");
            var amt = decimal.Parse(Console.ReadLine() ?? "0");

            _util.AddBillItem(billId, name, amt);
            Console.WriteLine("Item added.");
        }

        // ACTION UPDATE ITEM
        private void UpdateItem()
        {
            Console.Write("Item ID: ");
            var itemId = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Item name: ");
            var name = Console.ReadLine() ?? "";
            Console.Write("Amount: ");
            var amt = decimal.Parse(Console.ReadLine() ?? "0");

            _util.UpdateBillItem(itemId, name, amt);
            Console.WriteLine("Item updated.");
        }

        // ACTION DELETE ITEM
        private void DeleteItem()
        {
            Console.Write("Item ID: ");
            var itemId = int.Parse(Console.ReadLine() ?? "0");
            _util.DeleteBillItem(itemId);
            Console.WriteLine("Item deleted.");
        }

        // ACTION PAY
        private void Pay()
        {
            Console.Write("Bill ID: ");
            var billId = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Amount Paid: ");
            var amt = decimal.Parse(Console.ReadLine() ?? "0");
            Console.Write("Payment Mode: ");
            var mode = Console.ReadLine() ?? "";
            Console.Write("Reference No (optional): ");
            var refNo = Console.ReadLine();

            _util.RecordPayment(billId, amt, mode, string.IsNullOrWhiteSpace(refNo) ? null : refNo.Trim());
            Console.WriteLine("Payment recorded.");
        }

        // ACTION OUTSTANDING
        private void Outstanding()
        {
            var lines = _util.OutstandingBillsLines();
            if (lines.Count == 0) { Console.WriteLine("No outstanding bills."); return; }
            foreach (var line in lines) Console.WriteLine(line);
        }

        // MAIN MENU LOOP
        public void Start()
        {
            while (true)
            {
                Console.WriteLine("\n--- Billing Menu ---");
                Console.WriteLine("1. Generate Bill for Visit");
                Console.WriteLine("2. Add Bill Item");
                Console.WriteLine("3. Update Bill Item");
                Console.WriteLine("4. Delete Bill Item");
                Console.WriteLine("5. Record Payment");
                Console.WriteLine("6. View Outstanding Bills");
                Console.WriteLine("0. Back");
                Console.Write("Select: ");
                var ch = Console.ReadLine();

                try
                {
                    switch (ch)
                    {
                        case "1": Generate(); break;
                        case "2": AddItem(); break;
                        case "3": UpdateItem(); break;
                        case "4": DeleteItem(); break;
                        case "5": Pay(); break;
                        case "6": Outstanding(); break;
                        case "0": return;
                        default: Console.WriteLine("Invalid choice."); break;
                    }
                }
                catch (HealthClinicException ex) { Console.WriteLine($"Error: {ex.Message}"); }
            }
        }
    }
}
