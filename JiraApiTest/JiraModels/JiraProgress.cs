using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NSSC.CRM.Jira.JiraModels
{
    public class JiraProgress
    {
        public string progress { get; set; }
        public string total { get; set; }
        public string percent { get; set; }
    }
}