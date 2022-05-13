using Newtonsoft.Json;

namespace jira_reporter
{
    public class JiraIssueType
    {
        private string description;
        private string iconUrl;
        private string id;
        private string name;
        private string self;
        private bool subtask;

        public JiraIssueType()
        {
        }

        [JsonProperty("description")]
        public string Description { get => description; set => description = value; }
        [JsonProperty("iconUrl")]
        public string IconUrl { get => iconUrl; set => iconUrl = value; }
        [JsonProperty("id")]
        public string Id { get => id; set => id = value; }
        [JsonProperty("name")]
        public string Name { get => name; set => name = value; }
        [JsonProperty("self")]
        public string Self { get => self; set => self = value; }
        [JsonProperty("subtask")]
        public bool Subtask { get => subtask; set => subtask = value; }
    }
}