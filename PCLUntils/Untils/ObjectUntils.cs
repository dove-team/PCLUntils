using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PCLUntils.Objects
{
    public static class ObjectUntils
    {
        public static bool IsEmpty<T>(this T obj)
        {
            try
            {
                if (obj == null) return true;
                if (obj is string) return string.IsNullOrEmpty(obj.ToString());
                else return obj.Equals(default(T));
            }
            catch { }
            return true;
        }
        public static bool IsNotEmpty<T>(this T obj)
        {
            return !IsEmpty(obj);
        }
        public static bool RegexMatch(this string value, string regex, out string result)
        {
            result = string.Empty;
            try
            {
                result = Regex.Match(value, regex).Groups[1].Value;
                return result.IsNotEmpty();
            }
            catch
            {
                return false;
            }
        }
        public static bool IsEmptyArray<T>(this IEnumerable<T> obj)
        {
            if (obj == null) return true;
            if (obj.Count() <= 0) return true;
            return false;
        }
        public static bool IsNotEmptyArray<T>(this IEnumerable<T> obj)
        {
            if (obj == null) return false;
            if (obj.Count() <= 0) return false;
            return true;
        }
        public static string RegexMatch(this string input, string regular)
        {
            try
            {
                var data = Regex.Match(input, regular);
                if (data.Groups.Count >= 2 && string.IsNullOrEmpty(data.Groups[1].Value))
                    return data.Groups[1].Value;
            }
            catch { }
            return string.Empty;
        }
        public static long ToTimeStamp(this DateTime time)
        {
            DateTime Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (long)(time.AddHours(-8) - Jan1st1970).TotalMilliseconds;
        }
        public static DateTime ToDateTime(this long timeStamp)
        {
            var start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return start.AddMilliseconds(timeStamp).AddHours(8);
        }
        public static bool ToBoolean(this object obj, bool defaultValue = false)
        {
            if (obj == null)
                return defaultValue;
            try
            {
                if (obj is bool value)
                    return value;
                else
                    return Convert.ToBoolean(obj);
            }
            catch { }
            return defaultValue;
        }
        public static int ToInt32(this object obj, bool removeDecimalPoint = false, int defaultValue = 0)
        {
            if (obj == null)
                return defaultValue;
            try
            {
                var str = obj.ToString();
                if (int.TryParse(str, out int result))
                    return result;
                else
                {
                    if (removeDecimalPoint && int.TryParse(str.Split('.').FirstOrDefault(), out result))
                        return result;
                }
            }
            catch { }
            return defaultValue;
        }
        public static long ToInt64(this object obj, long defaultValue = 0)
        {
            if (obj == null)
                return defaultValue;
            try
            {
                var str = obj.ToString();
                if (long.TryParse(str, out long result))
                    return result;
                else
                    return Convert.ToInt64(str);
            }
            catch { return defaultValue; }
        }
    }
}