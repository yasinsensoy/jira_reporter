using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace jira_reporter
{
    public class JiraField
    {
        private JiraUser assignee;
        private List<JiraComponent> components;
        private DateTime? created;
        private JiraUser creator;
        private List<JiraCustom> daire;
        private DateTime? plannedStart;
        private DateTime? plannedEnd;
        private float? storyPoint;
        private JiraUser approvingPerson;
        private JiraUser teamLeader;
        private string result;
        private JiraCustom sprint;
        private float? finishPoint;
        private string description;
        private JiraIssueType issuetype;
        private JiraUser reporter;
        private JiraResolution resolution;
        private DateTime? resolutiondate;
        private JiraStatus status;
        private string summary;
        private DateTime? updated;
        private List<JiraIssueLink> issuelinks;
        private List<JiraAttachment> attachments;

        public JiraField()
        {
        }

        [JsonProperty("assignee")]
        public JiraUser Assignee { get => assignee; set => assignee = value; }
        [JsonProperty("components")]
        public List<JiraComponent> Components { get => components; set => components = value; }
        [JsonProperty("created")]
        public DateTime? Created { get => created; set => created = value; }
        [JsonProperty("creator")]
        public JiraUser Creator { get => creator; set => creator = value; }
        [JsonProperty("customfield_10300")]
        public List<JiraCustom> Daire { get => daire; set => daire = value; }
        [JsonProperty("customfield_10400")]
        public DateTime? PlannedStart { get => plannedStart; set => plannedStart = value; }
        [JsonProperty("customfield_10401")]
        public DateTime? PlannedEnd { get => plannedEnd; set => plannedEnd = value; }
        [JsonProperty("customfield_10413")]
        public float? StoryPoint { get => storyPoint; set => storyPoint = value; }
        [JsonProperty("customfield_10609")]
        public JiraUser ApprovingPerson { get => approvingPerson; set => approvingPerson = value; }
        [JsonProperty("customfield_10800")]
        public JiraUser TeamLeader { get => teamLeader; set => teamLeader = value; }
        [JsonProperty("customfield_10805")]
        public string Result { get => result; set => result = value; }
        [JsonProperty("customfield_10900")]
        public JiraCustom Sprint { get => sprint; set => sprint = value; }
        [JsonProperty("customfield_11000")]
        public float? FinishPoint { get => finishPoint; set => finishPoint = value; }
        [JsonProperty("description")]
        public string Description { get => description; set => description = value; }
        [JsonProperty("issuetype")]
        public JiraIssueType Issuetype { get => issuetype; set => issuetype = value; }
        [JsonProperty("reporter")]
        public JiraUser Reporter { get => reporter; set => reporter = value; }
        [JsonProperty("resolution")]
        internal JiraResolution Resolution { get => resolution; set => resolution = value; }
        [JsonProperty("resolutiondate")]
        public DateTime? Resolutiondate { get => resolutiondate; set => resolutiondate = value; }
        [JsonProperty("status")]
        public JiraStatus Status { get => status; set => status = value; }
        [JsonProperty("summary")]
        public string Summary { get => summary; set => summary = value; }
        [JsonProperty("updated")]
        public DateTime? Updated { get => updated; set => updated = value; }
        [JsonProperty("issuelinks")]
        public List<JiraIssueLink> Issuelinks { get => issuelinks; set => issuelinks = value; }
        [JsonProperty("attachment")]
        public List<JiraAttachment> Attachments { get => attachments; set => attachments = value; }
    }
}
