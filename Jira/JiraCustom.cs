using Newtonsoft.Json;

namespace jira_reporter
{
    public class JiraCustom
    {
        private string id;
        private string self;
        private string value;

        public JiraCustom()
        {
        }

        [JsonProperty("id")]
        public string Id { get => id; set => id = value; }
        [JsonProperty("self")]
        public string Self { get => self; set => self = value; }
        [JsonProperty("value")]
        public string Value { get => value; set => this.value = value; }
    }
}