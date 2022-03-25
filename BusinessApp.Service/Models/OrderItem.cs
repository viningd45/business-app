using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessApp.Service.Models
{
    public partial class OrderItem
    {
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? ItemCount { get; set; }
    }
}
