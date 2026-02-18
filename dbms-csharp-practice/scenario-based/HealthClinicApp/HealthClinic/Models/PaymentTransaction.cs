using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.Models
{
    public sealed class PaymentTransaction
    {
        // Payment identification
        public long PaymentId { get; set; }
        public int BillId { get; set; }
        
        // Payment details
        public decimal AmountPaid { get; set; }
        public string PaymentMode { get; set; } = "";
        public DateTime PaidAt { get; set; }
        
        // Reference information
        public string? ReferenceNo { get; set; }

        public override string ToString()
        {
            return $"Payment ID: {PaymentId} | Bill: {BillId} | Amount: {AmountPaid} | Mode: {PaymentMode} | Ref: {ReferenceNo}";
        }
    }
}
