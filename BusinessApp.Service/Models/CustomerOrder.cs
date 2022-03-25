using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessApp.Service.Models
{
    public partial class CustomerOrder
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }
        public bool? PaymentReceived { get; set; }
        public IEnumerable<OrderItem> Items{ get; set; }

    }
}
