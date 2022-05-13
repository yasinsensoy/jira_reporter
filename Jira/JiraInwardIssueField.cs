using Newtonsoft.Json;

namespace jira_reporter
{
    public class JiraInwardIssueField
    {
        private JiraIssueType issuetype;
        private JiraStatus status;
        private string summary;

        public JiraInwardIssueField()
        {
        }

        [JsonProperty("issuetype")]
        public JiraIssueType Issuetype { get => issuetype; set => issuetype = value; }
        [JsonProperty("status")]
        public JiraStatus Status { get => status; set => status = value; }
        [JsonProperty("summary")]
        public string Summary { get => summary; set => summary = value; }
    }
}