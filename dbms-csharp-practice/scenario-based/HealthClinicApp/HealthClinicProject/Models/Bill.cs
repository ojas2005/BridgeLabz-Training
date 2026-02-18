using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.Models
{
    public sealed class Bill
    {
        // Bill identification
        public int BillId { get; set; }
        public int VisitId { get; set; }
        public DateTime BillDate { get; set; }
        
        // Bill amount and status
        public decimal TotalAmount { get; set; }
        public string PaymentStatus { get; set; } = "UNPAID";

        public override string ToString()
        {
            return $"Bill ID: {BillId} | Visit: {VisitId} | Amount: {TotalAmount} | Status: {PaymentStatus}";
        }
    }
}
