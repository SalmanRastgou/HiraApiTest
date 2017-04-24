using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraApiTest.JiraModels
{
    class JiraUpdateFieldObject
    {
        public JiraUpdateField fields { get; set; }
    }
    class JiraUpdateField
    {
        public string summary { get; set; }
    }
}
