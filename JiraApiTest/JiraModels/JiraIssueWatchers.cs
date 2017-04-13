using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraApiTest.JiraModels
{
    public class JiraIssueWatchers
    {
        //public bool isWatching { get; set; }
        //public int watchCount { get; set; }
        public List<JiraWatcher> watchers { get; set; }
    }    

    public class JiraWatcher
    {
        public string name { get; set; }
        public string key { get; set; }
        public string emailAddress { get; set; }
        //public bool active { get; set; }
    }

}
