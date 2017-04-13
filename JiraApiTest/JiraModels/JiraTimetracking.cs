using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NSSC.CRM.Jira.JiraModels
{
    public class JiraTimetracking
    {
        public string remainingEstimate { get; set; }
        public string timeSpent { get; set; }
        public string remainingEstimateSeconds { get; set; }
        public string timeSpentSeconds { get; set; }
    }
}