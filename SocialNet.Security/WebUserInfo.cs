using System;
using System.Web;

namespace SocialNet.Security
{
    public class WebUserInfo
    {
        public long MyId => GetHeaderValue<long>(nameof(MyId));
        public string Email => GetHeaderValue<string>(nameof(Email));

        public T GetHeaderValue<T>(string key)
        {
            var header = HttpContext.Current.Request.Headers.Get(key);

            if (typeof(T) == typeof(long))
            {
                var val = long.Parse(header);
                return ChangeType<T>(val);
            }
            else if (typeof(T) == typeof(string))
            {
                return ChangeType<T>(header);
            }
            else
                throw new Exception("Нет такого типа");
        }

        private T ChangeType<T>(object value)
        {
            return (T) Convert.ChangeType(value, typeof(T));
        }
    }
}