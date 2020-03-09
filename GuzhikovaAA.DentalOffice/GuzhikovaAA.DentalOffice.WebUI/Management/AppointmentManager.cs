using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DentalOffice.WebUI.Management
{
    public class AppointmentManager
    {

        public DateTime GetValidDate(DateTime currentDate, out string dayOfWeek)
        {

            int currentDayOfWeek = (int)currentDate.DayOfWeek;
            DateTime validDate = default(DateTime);

            if(currentDayOfWeek == 0)
            {
                validDate = currentDate.AddDays(1);
                dayOfWeek = validDate.DayOfWeek.ToString();
            }else if  (currentDayOfWeek < 6)
            {
                validDate = currentDate;
                dayOfWeek = validDate.DayOfWeek.ToString();
            }
            else
            {
                validDate = currentDate.AddDays(2);
                dayOfWeek = validDate.DayOfWeek.ToString();
            }
            return validDate;
        }




        /// <summary>
        /// Compares two dates: today and announced
        /// </summary>
        /// <param name="tempDate"></param>
        /// <param name="currentDate"></param>
        /// <returns> < 0 − If today date is earlier than announced date
        /// 0 − If date1 is the same as date2
        /// > 0 − If date1 is later than date2</returns>
        //public  int CompareWhithCurrentDate(int dayOfWeek, int hour)
        //{
        //    //DateTime currentDate = DateTime.Now;
        //    //int currentDayOfWeek = (int)currentDate.DayOfWeek;

        //    //if(currentDate)

        //    //tempDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, i, 0, 0);
        //    //return
        //}
    }
}