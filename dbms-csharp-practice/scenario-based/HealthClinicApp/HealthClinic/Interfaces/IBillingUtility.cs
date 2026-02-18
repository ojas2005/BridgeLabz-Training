using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.Interfaces
{
    public interface IBillingUtility
    {
        void GenerateBill(int visitId);
        void AddBillItem(int billId, string itemName, decimal amount);
        void UpdateBillItem(int itemId, string itemName, decimal amount);
        void DeleteBillItem(int itemId);

        void RecordPayment(int billId, decimal amountPaid, string paymentMode, string? referenceNo);

        List<string> OutstandingBillsLines();
        List<string> RevenueReportLines(DateTime startDate, DateTime endDate);
    }
}
