using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraApiTest.JiraModels
{
    class JiraTransitionObject
    {
        public JiraTransitionComment update { get; set; }
        public JiraTransitionId transition { get; set; }
    }

    class JiraTransitionId
    {
        public string id { get; set; }
    }

    class JiraTransitionComment
    {
        public JiraTransitionAdd[] comment { get; set; }
    }

    class JiraTransitionAdd
    {
        public JiraTransitionBody add { get; set; }
    }

    class JiraTransitionBody
    {
        public string body { get; set; }
    }
}
