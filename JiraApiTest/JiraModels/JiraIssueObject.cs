using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NSSC.CRM.Jira.JiraModels
{
    public class JiraIssueObject
    {
        public string id { get; set; }
        public string key { get; set; }
        public string self { get; set; }
        public JiraIssueField fields { get; set; }
    }    
}