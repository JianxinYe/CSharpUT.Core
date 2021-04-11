using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class HolidayService
    {
        /* 
         * 如果是是聖誕節，則回傳＂Merry Xmas＂，
         * 如果不是聖誕節，則回傳＂Today is not Xmas＂
         */

        public string IsHoliday()
        {
            DateTime today = GetToday();
            if (today.Month == 12 && (today.Day == 25 || today.Day ==24))
            {
                return "Merry Xmas";
            }

            return "Today is not Xmas";
        }

        protected virtual DateTime GetToday()
        {
            // 利用 virtual 來讓測試案例可以進行測試
            return DateTime.Today;
        }
    }
}
