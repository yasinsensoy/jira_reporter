using Newtonsoft.Json;
using System.Drawing;

namespace jira_reporter
{
    public class JiraAvatar
    {
        private string x16;
        private string x24;
        private string x32;
        private string x48;

        public JiraAvatar()
        {
        }

        private Image getImage(string url)
        {
            Response res = Help.instance.getResponse(url, new RequestOptions(null, JiraApi.auth));
            return res.isError ? null : Image.FromStream(res.Stream);
        }

        [JsonIgnore]
        public Image ImageX16 => getImage(X16);
        [JsonIgnore]
        public Image ImageX24 => getImage(X24);
        [JsonIgnore]
        public Image ImageX32 => getImage(X32);
        [JsonIgnore]
        public Image ImageX48 => getImage(X48);

        [JsonProperty("16x16")]
        public string X16 { get => x16; set => x16 = value; }
        [JsonProperty("24x24")]
        public string X24 { get => x24; set => x24 = value; }
        [JsonProperty("32x32")]
        public string X32 { get => x32; set => x32 = value; }
        [JsonProperty("48x48")]
        public string X48 { get => x48; set => x48 = value; }
    }
}
