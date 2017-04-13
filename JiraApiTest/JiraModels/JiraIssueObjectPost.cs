using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NSSC.CRM.Jira.JiraModels
{
    public class JiraIssueObjectPost
    {
        public string id { get; set; }
        public string key { get; set; }
        public JiraIssueFieldPost fields { get; set; }
    }                            
}