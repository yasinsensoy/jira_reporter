using Newtonsoft.Json;
using System;
using System.Text;

namespace jira_reporter
{
    public static class Extensions
    {
        public static string toBase64(this string value) => Convert.ToBase64String(Encoding.ASCII.GetBytes(value));

        public static T jsonDeserialize<T>(this string value) where T : class => Help.instance.isJson(value) ? JsonConvert.DeserializeObject<T>(value) : null;
    }
}
