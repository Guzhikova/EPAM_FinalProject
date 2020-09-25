using DentalOffice.BLL.Interfaces;
using DentalOffice.Common;
using DentalOffice.Entities;
using DentalOffice.WebUI.Log4net;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace DentalOffice.WebUI.Management
{
    public class AppointmentManager
    {
        private AdministrationModule _adminMod = new AdministrationModule();
        private IRecordsLogic _recordLogic = DependencyResolver.RecordsLogic;
        DentalOfficeRoleProvider _roleProvider = new DentalOfficeRoleProvider();


        public DateTime GetValidDate(DateTime currentDate, out string dayOfWeek, int dayStep = 0)
        {

            int currentDayOfWeek = (int)currentDate.DayOfWeek;
            DateTime validDate = default(DateTime);

            if (currentDayOfWeek == 0)
            {
                validDate = (dayStep > 0) ? currentDate.AddDays(2) : currentDate.AddDays(1);
                dayOfWeek = DateTimeFormatInfo.CurrentInfo.GetDayName(validDate.DayOfWeek);
            }
            else if (currentDayOfWeek < 6)
            {
                validDate = currentDate;
                dayOfWeek = DateTimeFormatInfo.CurrentInfo.GetDayName(validDate.DayOfWeek);

            }
            else
            {
                validDate = currentDate.AddDays(2);
                dayOfWeek = DateTimeFormatInfo.CurrentInfo.GetDayName(validDate.DayOfWeek);
            }
            return validDate;
        }


        public Record CreateRecordFromRequest(string date, string time, string userLogin = null, Patient patient = null)
        {
            Record record = new Record();

            DateTime.TryParse(date, out DateTime recordDate);
            Int32.TryParse(time, out int recordTime);

            recordDate = new DateTime(recordDate.Year, recordDate.Month, recordDate.Day, recordTime, 0, 0);
            record.Date = recordDate;

            if (patient == null)
            {
                User user = _adminMod.GetUserByLogin(userLogin);
                record.Patient = user.PatientData;
            }
            else if (userLogin == null)
            {
                record.Patient = patient;
            }
            record = _recordLogic.Add(record);

            return record;
        }


        public List<Record> GetAllOnDate(DateTime date, out string errorMessage)
        {
            try
            {
                var records = _recordLogic.GetAllOnDate(date);
                errorMessage = "";

                return records.ToList();
            }
            catch (SqlException ex)
            {
                Logger.LogShortErrorInfo(ex);
                errorMessage = "Не удалось подключиться к базе данных стоматологического кабинета";
            }
            catch (Exception ex)
            {
                Logger.LogShortErrorInfo(ex);
                errorMessage = "Произошла непредвиденная ошибка.";
            }
            return null;
        }
        private DateTime GetFullDate(DateTime currentDate, int time)
        {

            return new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, time, 0, 0);
        }
    }
}