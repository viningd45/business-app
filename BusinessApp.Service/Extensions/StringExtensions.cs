using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApp.Service.Extensions
{
    public static class StringExtensions
    {
        public static bool HasValue(this string str)
        {
            return !String.IsNullOrEmpty(str);
        }
    }
}
