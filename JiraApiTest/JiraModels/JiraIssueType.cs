using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NSSC.CRM.Jira.JiraModels
{
    public class JiraIssueType
    {
        public string id { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public bool subtask { get; set; }
    }
}