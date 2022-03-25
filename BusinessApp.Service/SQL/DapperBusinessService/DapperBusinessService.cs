using BusinessApp.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApp.Service.SQL.DapperBusinessService
{
    public partial class DapperBusinessService : IBusinessService
    {
        // BusinessOwner
        // bizniz
        private readonly string _connectionString;

        public DapperBusinessService(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
