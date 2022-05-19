using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace PCLUntils.Json
{
    public static class JsonUntils
    {
        public static JObject ToJObject(this string json)
        {
            try
            {
                return JObject.Parse(json);
            }
            catch { }
            return default;
        }
        public static JObject ToJObject(this object obj)
        {
            try
            {
                if (obj != null)
                {
                    var json = obj.ToString();
                    return JObject.Parse(json);
                }
            }
            catch { }
            return default;
        }
        public static string ToString(this JToken token, string key, string defaultValue = "")
        {
            try
            {
                var result = token[key]?.ToString();
                if (!string.IsNullOrEmpty(result))
                    return result;
            }
            catch { }
            return defaultValue;
        }
        public static T ParseObject<T>(this object token)
        {
            try
            {
                return token.ToString().ParseObject<T>();
            }
            catch { }
            return default;
        }
        public static T ParseObject<T>(this string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch { }
            return default;
        }
        public static T ParseObject<T>(this string json, JsonSerializerSettings settings)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json, settings);
            }
            catch { }
            return default;
        }
        public static object ParseObject(this string json, Type type, JsonSerializerSettings settings)
        {
            try
            {
                return JsonConvert.DeserializeObject(json, type, settings);
            }
            catch { }
            return default;
        }
        public static bool TryParseObject<T>(this string json, out T obj)
        {
            obj = default;
            try
            {
                obj = JsonConvert.DeserializeObject<T>(json);
                return true;
            }
            catch { }
            return false;
        }
        public static bool TryParseObject<T>(this string json, JsonSerializerSettings settings, out T obj)
        {
            obj = default;
            try
            {
                obj = JsonConvert.DeserializeObject<T>(json, settings);
                return true;
            }
            catch { }
            return false;
        }
        public static bool TryParseObject(this string json, Type type, JsonSerializerSettings settings, out object obj)
        {
            obj = default;
            try
            {
                obj = JsonConvert.DeserializeObject(json, type, settings);
                return true;
            }
            catch { }
            return false;
        }
        public static string ParseJson<T>(this T obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj);
            }
            catch { }
            return string.Empty;
        }
    }
}