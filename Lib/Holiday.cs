using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;

namespace Lib
{
    public class Holiday
    {
        
        public string SayHello()
        {
            DateTime today = GetToday();
            if (today.Month == 12 && (today.Day == 25 || today.Day == 24))
            {
                return "Merry Xmas";
            }

            return "Today is not Xmas";


        }

        protected virtual DateTime GetToday()
        {
            return DateTime.Today;
        }

    }
}
