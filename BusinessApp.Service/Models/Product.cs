using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessApp.Service.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? Archived { get; set; }
        public Price ProductPrice { get; set; }
    }
}
