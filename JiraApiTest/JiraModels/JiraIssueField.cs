using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NSSC.CRM.Jira.JiraModels
{
    public class JiraIssueField
    {
        public JiraIssueType issuetype { get; set; }
        public string timespent { get; set; } 
        public JiraProject project { get; set; }
        public string lastViewed { get; set; }
        public DateTime created { get; set; }
        public JiraPriority priority { get; set; }
        public List<string> labels { get; set; }
        public JiraPerson assignee { get; set; }
        public DateTime updated { get; set; }
        public JiraStatus status { get; set; }
        public string description { get; set; }
        public JiraTimetracking timetracking { get; set; }
        public List<JiraAttachment> attachment { get; set; }
        public string summary { get; set; }
        public List<JiraSubtask> subtasks { get; set; }
        public JiraPerson reporter { get; set; }
        public JiraProgress progress { get; set; }
        public JiraComment comment { get; set; }
        public JiraWorklog worklog { get; set; }
        public string customfield_10200 { get; set; }
    }
}