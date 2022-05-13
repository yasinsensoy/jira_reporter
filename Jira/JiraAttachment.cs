using Newtonsoft.Json;
using System;

namespace jira_reporter
{
    public class JiraAttachment
    {
        private JiraUser author;
        private string content;
        private DateTime? created;
        private string filename;
        private string id;
        private string mimeType;
        private string self;
        private long size;
        private string thumbnail;

        public JiraAttachment()
        {
        }

        [JsonProperty("author")]
        public JiraUser Author { get => author; set => author = value; }
        [JsonProperty("content")]
        public string Content { get => content; set => content = value; }
        [JsonProperty("created")]
        public DateTime? Created { get => created; set => created = value; }
        [JsonProperty("filename")]
        public string Filename { get => filename; set => filename = value; }
        [JsonProperty("id")]
        public string Id { get => id; set => id = value; }
        [JsonProperty("mimeType")]
        public string MimeType { get => mimeType; set => mimeType = value; }
        [JsonProperty("self")]
        public string Self { get => self; set => self = value; }
        [JsonProperty("size")]
        public long Size { get => size; set => size = value; }
        [JsonProperty("thumbnail")]
        public string Thumbnail { get => thumbnail; set => thumbnail = value; }
    }
}