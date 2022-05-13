using Newtonsoft.Json;

namespace jira_reporter
{
    public class JiraResolution
    {
        private string description;
        private string id;
        private string name;
        private string self;

        public JiraResolution()
        {
        }

        [JsonProperty("description")]
        public string Description { get => description; set => description = value; }
        [JsonProperty("id")]
        public string Id { get => id; set => id = value; }
        [JsonProperty("name")]
        public string Name { get => name; set => name = value; }
        [JsonProperty("self")]
        public string Self { get => self; set => self = value; }
    }
}