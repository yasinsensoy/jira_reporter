using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text;

namespace jira_reporter
{
    public static class Extensions
    {
        public static string toBase64(this string value) => Convert.ToBase64String(Encoding.ASCII.GetBytes(value));

        public static bool isJson(this string value)
        {
            try
            {
                JToken.Parse(value);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static T jsonDeserialize<T>(this string value) where T : class => value.isJson() ? JsonConvert.DeserializeObject<T>(value) : null;

        public static byte[] toByte(this Stream value)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                value.CopyTo(stream);
                return stream.ToArray();
            }
        }
    }
}
