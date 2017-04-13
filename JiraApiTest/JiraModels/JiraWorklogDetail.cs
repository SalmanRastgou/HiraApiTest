using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NSSC.CRM.Jira.JiraModels
{
    public class JiraWorklogDetail
    {
        public JiraPerson author { get; set; }
        public JiraPerson updateAuthor { get; set; }        
        public string comment { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
        public DateTime started { get; set; }
        public string timeSpent { get; set; }
        public string timeSpentSeconds { get; set; }
        public string id { get; set; }
    }
}