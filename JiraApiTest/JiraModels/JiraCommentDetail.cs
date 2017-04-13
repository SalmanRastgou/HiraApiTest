using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NSSC.CRM.Jira.JiraModels
{
    public class JiraCommentObject
    {
        public string self { get; set; }
        public string id { get; set; }
        public string body { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
        public JiraPerson author { get; set; }
        public JiraPerson updateAuther { get; set; }
        public JiraCommentVisibility visibility { get; set; }
    }

    public class JiraCommentVisibility
    {
        public string type { get; set; }
        public string value { get; set; }
    }
}