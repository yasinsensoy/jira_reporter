using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jira_reporter
{
    public class JiraJql
    {
        private string expand;
        private List<JiraIssues> issues;
        private long maxResults;
        private long startAt;
        private long total;

        public JiraJql()
        {

        }

        [JsonProperty("expand")]
        public string Expand { get => expand; set => expand = value; }
        [JsonProperty("issues")]
        public List<JiraIssues> Issues { get => issues; set => issues = value; }
        [JsonProperty("maxResults")]
        public long MaxResults { get => maxResults; set => maxResults = value; }
        [JsonProperty("startAt")]
        public long StartAt { get => startAt; set => startAt = value; }
        [JsonProperty("total")]
        public long Total { get => total; set => total = value; }
    }
}
