using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabz.gcr_codebase.oops_csharp_practice.inheritence.Multilevel_Inheritance.OnlineRetailOrderManagement
{
    internal class DeliveredOrder : ShippedOrder
    {
        string DeliveryDate;
        public DeliveredOrder(int orderId, string orderDate, string trackingNumber, string deliveryDate)
            : base(orderId, orderDate, trackingNumber)
        {
            this.DeliveryDate = deliveryDate;
        }

        public override string ToString()
        {
            return base.ToString() + $" , Delivery Date : {DeliveryDate}";
        }
    }
}
