using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jira_reporter
{
    public class JiraIssues
    {
        private string expand;
        private List<JiraFields> fields;
        private string id;
        private string key;
        private string self;

        public JiraIssues()
        {

        }

        [JsonProperty("expand")]
        public string Expand { get => expand; set => expand = value; }
        [JsonProperty("fields")]
        public List<JiraFields> Fields { get => fields; set => fields = value; }
        [JsonProperty("id")]
        public string Id { get => id; set => id = value; }
        [JsonProperty("key")]
        public string Key { get => key; set => key = value; }
        [JsonProperty("self")]
        public string Self { get => self; set => self = value; }
    }
}
