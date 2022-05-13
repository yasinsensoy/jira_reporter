using Newtonsoft.Json;

namespace jira_reporter
{
    public class JiraUser
    {
        private bool active;
        private JiraAvatar avatarUrls;
        private string displayName;
        private string emailAddress;
        private string name;
        private string self;

        public JiraUser()
        {
        }

        [JsonProperty("active")]
        public bool Active { get => active; set => active = value; }
        [JsonProperty("avatarUrls")]
        public JiraAvatar AvatarUrls { get => avatarUrls; set => avatarUrls = value; }
        [JsonProperty("displayName")]
        public string DisplayName { get => displayName; set => displayName = value; }
        [JsonProperty("emailAddress")]
        public string EmailAddress { get => emailAddress; set => emailAddress = value; }
        [JsonProperty("name")]
        public string Name { get => name; set => name = value; }
        [JsonProperty("self")]
        public string Self { get => self; set => self = value; }
    }
}
