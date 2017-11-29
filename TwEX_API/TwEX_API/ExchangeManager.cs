using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace TwEX_API
{
    public class ExchangeManager
    {
        // GETTERS
        public static String GetNonce()
        {
            long ms = (long)((DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds);
            return ms.ToString();
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
}
