using Newtonsoft.Json;

namespace jira_reporter
{
    public class JiraStatusCategory
    {
        private string colorName;
        private int id;
        private string key;
        private string name;
        private string self;

        public JiraStatusCategory()
        {
        }

        [JsonProperty("colorName")]
        public string ColorName { get => colorName; set => colorName = value; }
        [JsonProperty("id")]
        public int Id { get => id; set => id = value; }
        [JsonProperty("key")]
        public string Key { get => key; set => key = value; }
        [JsonProperty("name")]
        public string Name { get => name; set => name = value; }
        [JsonProperty("self")]
        public string Self { get => self; set => self = value; }
    }
}