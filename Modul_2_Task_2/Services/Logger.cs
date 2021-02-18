using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul_2_Practice_1.Entities;

namespace Modul_2_Practice_1.Services
{
    public class Logger
    {
        private readonly StringBuilder _logText;
        private static readonly Logger _instance = new Logger();

        private Logger()
        {
            _logText = new StringBuilder();
        }

        public static Logger Instance
        {
            get { return _instance; }
        }

        public void Log(LogType logType, string message)
        {
            var logMessage = $"{DateTime.UtcNow}: {logType}: {message}";
            Console.WriteLine(logMessage);
            _logText.AppendLine(logMessage);
        }

        public void LogInfo(string message)
        {
            Log(LogType.Info, message);
        }

        public void LogWarning(string message)
        {
            Log(LogType.Warning, message);
        }

        public void LogError(string message)
        {
            Log(LogType.Error, message);
        }

        public string GetLogs()
        {
            return _logText.ToString();
        }
    }
}
