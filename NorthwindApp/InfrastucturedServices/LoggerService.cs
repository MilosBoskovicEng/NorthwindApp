using System;
using System.IO;

namespace InfrastucturedServices
{
    public class LoggerService
    {
        private const string filePathInfo = @"C:\Temp\NorthwindInfoLog.txt";
        private const string filePathError = @"C:\Temp\NorthwindErrorLog.txt";

        public void logInfo(DateTime dateTime, string log)
        {
            using (StreamWriter streamWriterInfo = new StreamWriter(filePathInfo, true))
            {             
                streamWriterInfo.WriteLine(dateTime.ToString() + " " + log);
            }
        }

        public void logError(DateTime dateTime, string log)
        {
            using (StreamWriter streamWriterError = new StreamWriter(filePathError, true))
            {
                streamWriterError.WriteLine(dateTime.ToString() + " " + log);
            }
        }
    }
}
