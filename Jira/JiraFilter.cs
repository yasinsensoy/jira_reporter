using Newtonsoft.Json;

namespace jira_reporter
{
    public class JiraFilter
    {
        private bool favourite;
        private string id;
        private string name;
        private JiraUser owner;
        private string searchUrl;
        private string self;
        private string viewUrl;

        public JiraFilter()
        {
        }

        [JsonProperty("favourite")]
        public bool Favourite { get => favourite; set => favourite = value; }
        [JsonProperty("id")]
        public string Id { get => id; set => id = value; }
        [JsonProperty("name")]
        public string Name { get => name; set => name = value; }
        [JsonProperty("owner")]
        public JiraUser Owner { get => owner; set => owner = value; }
        [JsonProperty("searchUrl")]
        public string SearchUrl { get => searchUrl; set => searchUrl = value; }
        [JsonProperty("self")]
        public string Self { get => self; set => self = value; }
        [JsonProperty("viewUrl")]
        public string ViewUrl { get => viewUrl; set => viewUrl = value; }
    }
}