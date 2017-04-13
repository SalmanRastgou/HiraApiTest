using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JiraApiTest.TestClass
{
    public class JiraResponse
    {
        public HttpStatusCode StatusCode { get; set; }

        public List<string> JiraErrors { get; set; }
    }
}
