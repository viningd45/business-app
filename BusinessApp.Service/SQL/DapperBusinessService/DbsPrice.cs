using BusinessApp.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApp.Service.SQL.DapperBusinessService
{
    public partial class DapperBusinessService
    {
        public int CreatePrice(Price price) { return 0; }
        public int CreatePrice(int productId, int price, DateTime? startDate = null) => 0;
        public Price GetPrice(int productId, DateTime? requestDate = null) => null;
        public Price GetPrice(int productId) => null;
        public IEnumerable<Price> GetPriceHistory(DateTime from) => null;
    }
}
