using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.Models
{
    public sealed class BillItem
    {
        // Item identification
        public int ItemId { get; set; }
        public int BillId { get; set; }
        
        // Item details and amount
        public string ItemName { get; set; } = "";
        public decimal Amount { get; set; }

        public override string ToString()
        {
            return $"Item ID: {ItemId} | {ItemName} | Amount: {Amount}";
        }
    }
}
