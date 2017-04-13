using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NSSC.CRM.Jira.JiraModels
{
    public class JiraComment
    {
        public List<JiraCommentObject> comments { get; set; }
    }
}