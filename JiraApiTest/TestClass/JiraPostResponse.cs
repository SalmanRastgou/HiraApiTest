using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraApiTest.TestClass
{
    class JiraPostResponse : JiraResponse
    {
        public string IssueKey { get; set; }
    }
}
