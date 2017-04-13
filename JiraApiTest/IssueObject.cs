using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraApiTest
{
    public class IssueObject
    {
        public string id { get; set; }
        public string key { get; set; }
        public Fields fields { get; set; }
    }

    public class Fields
    {
        public Project project { get; set; }
        public string summary { get; set; }
        public string description { get; set; }
        public IssueType issuetype { get; set; }
    }

    public class Project
    {
        public string key { get; set; }
    }

    public class IssueType
    {
        public string name { get; set; }
        public string key { get; set; }
    }
}
