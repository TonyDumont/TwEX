using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace TwEX_API
{
    public class LogManager
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
            LogMessageList.Insert(0, logMessage);
        }
        // ENUMS
        public enum LogMessageType
        {
            LOG,
            DEBUG,
            EXCHANGE,
            EXCEPTION,
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

    public static class EnumUtils
    {
        private static class EnumCache<T>
        {
            static readonly Type EnumType = typeof(T);
            static readonly Dictionary<T, string> FieldDescriptions = new Dictionary<T, string>();

            public static IDictionary<T, string> CachedDescriptions
            {
                get { return new Dictionary<T, string>(FieldDescriptions); }
            }

            public static string GetDescription(T value, string defaultValue)
            {
                string result = null;
                if (FieldDescriptions.ContainsKey(value))
                {
                    result = FieldDescriptions[value];
                }
                else
                {
                    lock (FieldDescriptions)
                    {
                        if (FieldDescriptions.ContainsKey(value))
                        {
                            result = FieldDescriptions[value];
                        }
                        else
                        {
                            FieldInfo fi = EnumType.GetField(value.ToString());
                            result = GetMemberDescription(fi, false);
                            FieldDescriptions[value] = result;
                        }
                    }
                }

                return result ?? defaultValue;
            }

            public static void LoadDescriptions()
            {
                lock (FieldDescriptions)
                {
                    FieldInfo[] fields = EnumType.GetFields();
                    if (null != fields)
                    {
                        T value;
                        FieldInfo field;
                        for (int i = 0; i < fields.Length; i++)
                        {
                            field = fields[i];
                            if (0 != (FieldAttributes.Static & field.Attributes))
                            {
                                value = (T)field.GetValue(null);
                                if (!FieldDescriptions.ContainsKey(value))
                                {
                                    FieldDescriptions[value] = GetMemberDescription(field, false);
                                }
                            }
                        }
                    }
                }
            }
        }

        private static string GetMemberDescription(MemberInfo member, bool inherited)
        {
            string result = null;

            if (null != member)
            {
                object[] attrs = member.GetCustomAttributes(typeof(DescriptionAttribute), inherited);
                if (null != attrs && 0 != attrs.Length)
                {
                    result = ((DescriptionAttribute)attrs[0]).Description;
                    if (null != result && 0 == result.Length) result = null;
                }
            }

            return result;
        }

        public static string GetDescription<T>(T value, string defaultValue)
        {
            return EnumCache<T>.GetDescription(value, defaultValue);
        }

        public static string GetDescription<T>(T value)
        {
            return EnumCache<T>.GetDescription(value, string.Empty);
        }

        public static IDictionary<T, string> GetAllDescriptions<T>()
        {
            EnumCache<T>.LoadDescriptions();
            return EnumCache<T>.CachedDescriptions;
        }
    }
    public static class Extensions
    {
        public static void SetProperty(this object obj, string propertyName, object value)
        {
            var propertyInfo = obj.GetType().GetProperty(propertyName);
            if (propertyInfo == null) return;
            propertyInfo.SetValue(obj, value);
        }
    }
}
