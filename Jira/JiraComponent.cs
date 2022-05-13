using Newtonsoft.Json;

namespace jira_reporter
{
    public class JiraComponent
    {
        private string id;
        private string name;
        private string self;

        public JiraComponent()
        {
        }

        [JsonProperty("id")]
        public string Id { get => id; set => id = value; }
        [JsonProperty("name")]
        public string Name { get => name; set => name = value; }
        [JsonProperty("self")]
        public string Self { get => self; set => self = value; }
    }
}
