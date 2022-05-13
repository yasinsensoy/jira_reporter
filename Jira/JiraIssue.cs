using Newtonsoft.Json;

namespace jira_reporter
{
    public class JiraIssue
    {
        private string expand;
        private JiraField fields;
        private string id;
        private string key;
        private string self;

        public JiraIssue()
        {
        }

        [JsonProperty("expand")]
        public string Expand { get => expand; set => expand = value; }
        [JsonProperty("fields")]
        public JiraField Fields { get => fields; set => fields = value; }
        [JsonProperty("id")]
        public string Id { get => id; set => id = value; }
        [JsonProperty("key")]
        public string Key { get => key; set => key = value; }
        [JsonProperty("self")]
        public string Self { get => self; set => self = value; }
    }
}
