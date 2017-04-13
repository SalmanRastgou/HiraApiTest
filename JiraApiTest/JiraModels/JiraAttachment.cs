using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NSSC.CRM.Jira.JiraModels
{
    public class JiraAttachment
    {
        public string id { get; set; }
        public string filename { get; set; }
        public JiraPerson author { get; set; }
        public DateTime ccreated { get; set; }
        public int size { get; set; }
        public string mimeType { get; set; }
        public string content { get; set; }
        public string thumbnail { get; set; }
    }
}