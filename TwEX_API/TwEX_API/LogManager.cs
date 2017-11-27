using System;
using System.ComponentModel;

namespace TwEX_API
{
    class LogManager
    {
        // PROPERTIES
        public static BindingList<LogMessage> LogMessageList = new BindingList<LogMessage>();
        // FUNCTIONS
        public static void AddLogMessage(String source, String functionCall, String message, LogMessageType type = LogMessageType.LOG)
        {
            LogMessage logMessage = new LogMessage();
            logMessage.TimeStamp = DateTime.Now;
            logMessage.Source = source;
            logMessage.FunctionCall = functionCall;
            logMessage.Message = message;
            logMessage.type = type;
            LogMessageList.Add(logMessage);
        }
        // ENUMS
        public enum LogMessageType
        {
            LOG,
            DEBUG,
            EXCHANGE,
            OTHER
        }
        // MODELS
        public class LogMessage
        {
            public DateTime TimeStamp { get; set; }
            public string Source { get; set; }
            public string FunctionCall { get; set; }
            public string Message { get; set; }
            public LogMessageType type { get; set; }
        }
    }
}
