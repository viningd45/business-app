using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessApp.Service.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? Zip { get; set; }
        public string Street { get; set; }
        public string Suite { get; set; }
        public int? Archived { get; set; }
    }
}
