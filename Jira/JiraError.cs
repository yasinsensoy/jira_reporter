using Newtonsoft.Json;
using System.Collections.Generic;

namespace jira_reporter
{
    public class JiraError
    {
        private List<string> errorMessages;

        public JiraError()
        {
        }

        [JsonProperty("errorMessages")]
        public List<string> ErrorMessages { get => errorMessages; set => errorMessages = value; }
        [JsonIgnore]
        public string Errors => string.Join("\r\n", ErrorMessages);
    }
}