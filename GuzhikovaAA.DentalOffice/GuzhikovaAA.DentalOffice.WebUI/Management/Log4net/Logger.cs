﻿using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DentalOffice.WebUI.Log4net
{
    public class Logger
    {
        private static ILog _log = LogManager.GetLogger("LOGGER");

        public static ILog Log
        {
            get { return _log; }
        }

        public static void InitLogger()
        {
            XmlConfigurator.Configure();
        }

        public static void LogShortErrorInfo(Exception ex)
        {
            string message = $"{Environment.NewLine} ~ {ex.Message}.{Environment.NewLine} ~ Stack Trace: {ex.StackTrace}";
            Log.Error(message + Environment.NewLine);
        }
    }
}