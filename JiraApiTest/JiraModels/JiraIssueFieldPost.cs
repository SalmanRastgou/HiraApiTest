using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NSSC.CRM.Jira.JiraModels
{
    public class JiraIssueFieldPost
    {

        public JiraIssueType issuetype { get; set; }
        public JiraProject project { get; set; }
        public IEnumerable<string> labels { get; set; }
        public string description { get; set; }
        public string summary { get; set; }
    }
}