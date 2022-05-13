using Newtonsoft.Json;

namespace jira_reporter
{
    public class JiraIssueLink
    {
        private string id;
        private JiraInwardIssue inwardIssue;
        private string self;

        public JiraIssueLink()
        {
        }

        [JsonProperty("id")]
        public string Id { get => id; set => id = value; }
        [JsonProperty("inwardIssue")]
        public JiraInwardIssue InwardIssue { get => inwardIssue; set => inwardIssue = value; }
        [JsonProperty("self")]
        public string Self { get => self; set => self = value; }
    }
}