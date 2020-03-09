using DentalOffice.BLL.Interfaces;
using DentalOffice.Common;
using DentalOffice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DentalOffice.WebUI.Management
{
    public class AppointmentManager
    {
        private AdministrationModule _adminMod = new AdministrationModule();
        private IRecordsLogic _recordLogic = DependencyResolver.RecordsLogic;
        DentalOfficeRoleProvider _roleProvider = new DentalOfficeRoleProvider();

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

        
        public Record CreateRecordFromRequest(HttpRequestBase request, string userLogin)
        {
            Record record = new Record();

            DateTime.TryParse(request["date"], out DateTime date);
            Int32.TryParse(request["time"], out int time);

            date = new DateTime(date.Year, date.Month, date.Day, time, 0, 0);

            User user = _adminMod.GetUserByLogin(userLogin);
    

            record.Date = date;
            record.Patient = user.PatientData;

            record = _recordLogic.Add(record);

            return record;
        }


        private DateTime GetFullDate(DateTime currentDate, int time)
        {

            return new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, time, 0, 0);
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