using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NSSC.CRM.Jira.JiraModels
{
    public class JiraWorklog
    {
        public List<JiraWorklogDetail> worklogs { get; set; }
    }
}