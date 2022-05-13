using Newtonsoft.Json;

namespace jira_reporter
{
    public class JiraInwardIssue
    {
        private JiraInwardIssueField field;
        private string id;
        private string key;
        private string self;

        public JiraInwardIssue()
        {
        }

        [JsonProperty("fields")]
        public JiraInwardIssueField Field { get => field; set => field = value; }
        [JsonProperty("id")]
        public string Id { get => id; set => id = value; }
        [JsonProperty("key")]
        public string Key { get => key; set => key = value; }
        [JsonProperty("self")]
        public string Self { get => self; set => self = value; }
    }
}