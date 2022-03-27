using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessApp.Service.Models
{
    public partial class Price
    {
        public int ProductId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Amount { get; set; }
    }
}
