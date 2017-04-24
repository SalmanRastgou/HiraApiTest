using JiraApiTest.JiraModels;
using JiraApiTest.TestClass;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NSSC.CRM.Jira.JiraModels;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JiraApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //IssueObject issue = new IssueObject()
            //{
            //    fields = new JiraApiTest.Fields()
            //    {
            //        project = new Project() { key = "SATP" },
            //        summary = "Salman tests Rest",
            //        description = "Here is the demonestration of creatin an issue inside Jira",
            //        issuetype = new JiraApiTest.IssueType() { name = "Bug" }
            //    }                
            //};
            //string jsonStr = JsonConvert.SerializeObject(issue); 

            //var dasd = JsonConvert.DeserializeObject<List<string>>("fsdfs");

            //GetIssue("SATP-29");

            //CreateIssueRest();

            EditIssueRestSharp("MARZEHR-219");

            //GetAllIssuesInProjectRestSharp("SATP");

            //GetIssuesUnderEpicRestSharp("SATP", "SATP-31");

            //CreateComment("MARZEHR-196","Test Comments TT-1");
            //GetIssueCommentsRestSharp("MARZEHR-219");




            //GetIssuesReportedForClientRestSharp("MARZEHR", "ticket_gateway");            
            //ConnectionCheck();

            //GetAvailableStatus();

            //AddWatcher("MARZEHR-129", "Charles");

            GetIssueRestSharp("MARZEHR-219");   //169         

            //DeleteComment("MARZEHR-196","10811");
            //GetAvailableTransitions("MARZEHR-196");
            //ChangeIssueStatus("MARZEHR-208",421);

            //GetIssueStatus("MARZEHR-197");

            //List<string> lst = new List<string>();
            //lst.Add("ss");
            //JiraPostResponse jiraPostResponse = new JiraPostResponse() { IssueKey = "Mz-191", StatusCode = HttpStatusCode.Conflict, JiraErrors = lst};
            //TestInheritence(jiraPostResponse);

            //GetGroups();            
            DownloadAttachment();
        }

        static void TestInheritence(JiraResponse jiraResponse)
        {
            var item1 = jiraResponse.JiraErrors;
            var item2 = jiraResponse.StatusCode;            
        }

        static void GetIssue(string key)
        {            
            string getIssue = "https://neustyle.atlassian.net/rest/api/2/issue/" + key;

            string url = getIssue;
            WebRequest myReq = WebRequest.Create(url);
            string credentials = $"{Credential.Username}:{Credential.Password}";

            CredentialCache mycache = new CredentialCache();
            myReq.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(credentials));

            WebResponse wr = myReq.GetResponse();
            Stream receiveStream = wr.GetResponseStream();
            StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);
            string content = reader.ReadToEnd();
            Console.WriteLine(content);
            var json = "[" + content + "]"; // change this to array
            var objects = JArray.Parse(json); // parse as array         
        }

        static void CreateIssue(string data)
        {            
            string createIssue = "https://neustyle.atlassian.net/rest/api/2/issue/";

            string url = createIssue;
            WebRequest myReq = (HttpWebRequest)WebRequest.Create(url);
            string credentials = $"{Credential.Username}:{Credential.Password}";

            CredentialCache mycache = new CredentialCache();
            myReq.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(credentials));
            myReq.ContentType = "application/json";
            myReq.Method = "POST";

            using (StreamWriter writer = new StreamWriter(myReq.GetRequestStream()))
            {
                writer.Write(data);
                writer.Flush();
                writer.Close();
            }

            var httpResponse = (HttpWebResponse)myReq.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }




        }

        static void CreateIssueRestSharp()
        {
            var client = new RestClient("https://neustyle.atlassian.net/rest/api/2");
            var request = new RestRequest("issue/", Method.POST);

            client.Authenticator = new HttpBasicAuthenticator(Credential.Username,Credential.Password);

            IssueObject issue = new IssueObject()
            {
                fields = new JiraApiTest.Fields()
                {
                    project = new Project() { key = "SATP" },
                    summary = "Salman tests RestSharp",
                    description = "Here is the demonestration of creatin an issue inside Jira whith Rest Sharp",
                    issuetype = new JiraApiTest.IssueType() { name = "Bug" }
                }
            };
            

            request.AddJsonBody(issue);

            var res = client.Execute<IssueObject>(request);

            if (res.StatusCode == HttpStatusCode.Created)
            {
                Console.WriteLine("Issue: {0} successfully created", res.Data.key);

                #region Attachment            
                request = new RestRequest(string.Format("issue/{0}/attachments", res.Data.key), Method.POST);

                request.AddHeader("X-Atlassian-Token", "nocheck");

                var file = File.ReadAllBytes(@"d:\SalPic.jpg");

                request.AddHeader("Content-Type", "multipart/form-data");
                request.AddFileBytes("file", file, "FB_IMG_1445253679378.jpg", "application/octet-stream");

                var res2 = client.Execute(request);

                Console.WriteLine(res2.StatusCode == HttpStatusCode.OK ? "Attachment added!" : res2.Content);
                #endregion
            }
            else
                Console.WriteLine(res.Content);
        }

        static void EditIssueRestSharp(string key)
        {
            var client = new RestClient("https://neustylesoftware.atlassian.net/rest/api/2");
            var request = new RestRequest($"issue/{key} ", Method.GET);

            client.Authenticator = new HttpBasicAuthenticator(Credential.Username, Credential.Password);

            var res = client.Execute<JiraIssueObject>(request);

            if (res.StatusCode == HttpStatusCode.OK)
            {
                var modifiedSammary = res.Data.fields.summary + " - Updated summary";

                JiraUpdateFieldObject updatefield = new JiraModels.JiraUpdateFieldObject() { fields = new JiraUpdateField() { summary = modifiedSammary}  };
                var jsonPayLoad = JsonConvert.SerializeObject(updatefield);
                

                request = new RestRequest($"issue/{res.Data.key} ", Method.PUT);
                request.AddHeader("Content-Type", "application/json");

                request.Parameters.Clear();
                request.AddParameter("application/json", jsonPayLoad, ParameterType.RequestBody);                                

                var res2 = client.Execute(request);
            }
        }

        static void GetAllIssuesInProjectRestSharp(string projectKey)
        {
            var client = new RestClient("https://neustyle.atlassian.net/rest/api/2");
            var request = new RestRequest($"search?jql=project={projectKey}", Method.GET);

            client.Authenticator = new HttpBasicAuthenticator(Credential.Username, Credential.Password);

            var res = client.Execute<IssueObject>(request);

            if (res.StatusCode == HttpStatusCode.OK)
            {

                
            }
        }

        static void GetIssuesUnderEpicRestSharp(string projectKey, string epicKey)
        {            
            var client = new RestClient("https://neustyle.atlassian.net/rest/api/2/");
            //var request = new RestRequest($"search?jql=project={projectKey}&Epic Link={epicKey}", Method.GET);
            var request = new RestRequest($"search", Method.POST);            

            client.Authenticator = new HttpBasicAuthenticator(Credential.Username, Credential.Password);

            JqlObject query = new JqlObject()
            {
                jql = $"project={projectKey}"
                //jql = $"cf[10005]=SATP-30"
            };
            request.AddJsonBody(query);

            var res = client.Execute<IssueObject>(request);
        }

        static void GetIssueCommentsRestSharp(string key)
        {
            var client = new RestClient("https://neustylesoftware.atlassian.net/rest/api/2/");            
            var request = new RestRequest($"issue/{key}/comment", Method.GET);

            client.Authenticator = new HttpBasicAuthenticator(Credential.Username, Credential.Password);            

            var res = client.Execute<JiraComment>(request);            

        }

        static void GetIssuesReportedForClientRestSharp(string projectKey, string reporter)
        {
            var client = new RestClient("https://neustylesoftware.atlassian.net/rest/api/2");
            var request = new RestRequest($"search?jql=project={projectKey} and reporter={reporter}", Method.GET);

            client.Authenticator = new HttpBasicAuthenticator(Credential.Username, Credential.Password);

            var result = client.Execute(request);

            var issues = JObject.Parse(result.Content);
            IList<JToken> issueList = issues["issues"].Children().ToList();

            List<JiraIssueObject> issueObjectList = new List<JiraIssueObject>();
            foreach (var issue in issueList)
            {
                var issueStr = issue.ToString();
                var issueObj = JsonConvert.DeserializeObject<JiraIssueObject>(issueStr);
                issueObjectList.Add(issueObj);
            }
            

            

        }        

        static void GetIssueRestSharp(string key)
        {
            var client = new RestClient($"https://neustylesoftware.atlassian.net/rest/api/2");
            var request = new RestRequest($"issue/{key}", Method.GET);

            client.Authenticator = new HttpBasicAuthenticator(Credential.Username, Credential.Password);

            var result = client.Execute<JiraIssueObject>(request);                        
        }

        static bool ConnectionCheck()
        {
            var client = new RestClient($"https://neustylesoftware.atlassian.net/rest/api/2");
            var request = new RestRequest($"myself", Method.GET);

            client.Authenticator = new HttpBasicAuthenticator(Credential.Username, Credential.Password);

            var result = client.Execute(request);

            if (result.StatusCode == HttpStatusCode.OK)
                return true;
            else
                return false;
            
        }

        static void GetAvailableTransitions(string key)
        {
            var client = new RestClient($"https://neustylesoftware.atlassian.net/rest/api/2");
            var request = new RestRequest($"issue/{key}/transitions", Method.GET);

            client.Authenticator = new HttpBasicAuthenticator(Credential.Username, Credential.Password);

            var result = client.Execute(request);
        }

        static void ChangeIssueStatus(string key)
        {
            var client = new RestClient($"https://neustylesoftware.atlassian.net/rest/api/2");
            var request = new RestRequest($"issue/{key}/transitions?expand=transitions.fields", Method.POST);

            JiraTransitionAdd[] assss = new JiraTransitionAdd[1];
            assss[0] = new JiraTransitionAdd() { add = new JiraTransitionBody() { body = "This is a test comment to change the status of an issue" } };
            JiraTransitionObject newTransition = new JiraTransitionObject()
            {
                transition = new JiraTransitionId() { id = "311"},                            
                update = new JiraModels.JiraTransitionComment() { comment = assss}
            };            
            request.AddJsonBody(newTransition);

            

            client.Authenticator = new HttpBasicAuthenticator(Credential.Username, Credential.Password);

            var result = client.Execute(request);
        }

        static void ChangeIssueStatus(string issueKey, int transitionId)
        {           
            int transition = (int)transitionId;
            var client = new RestClient($"https://neustylesoftware.atlassian.net/rest/api/2");
            var request = new RestRequest($"issue/{issueKey}/transitions?expand=transitions.fields", Method.POST);

            client.Authenticator = new HttpBasicAuthenticator(Credential.Username, Credential.Password);

            JiraTransitionObject jiraTransitionObject = new JiraTransitionObject() { transition = new JiraTransitionId() { id = transition.ToString() } };
            request.AddJsonBody(jiraTransitionObject);

            var result = client.Execute(request);            
        }

        static void GetAvailableStatus()
        {
            var client = new RestClient($"https://neustylesoftware.atlassian.net/rest/api/2");
            var request = new RestRequest($"status", Method.GET);

            client.Authenticator = new HttpBasicAuthenticator(Credential.Username, Credential.Password);

            var result = client.Execute(request);
        }

        static void AddWatcher(string key,string watcherName)
        {
            var client = new RestClient($"https://neustylesoftware.atlassian.net/rest/api/2");
            var request = new RestRequest($"issue/{key}/watchers?charles", Method.POST);

            client.Authenticator = new HttpBasicAuthenticator(Credential.Username, Credential.Password);

            request.AddJsonBody(watcherName);

            var result = client.Execute(request);
            
        }

        static void GetIssueStatus(string issueKey)
        {            
            var client = new RestClient($"https://neustylesoftware.atlassian.net/rest/api/2");
            var request = new RestRequest($"issue/{issueKey}/status", Method.GET);
            client.Authenticator = new HttpBasicAuthenticator(Credential.Username, Credential.Password);

            var result = client.Execute(request);            
        }

        static void AddComment(string issueKey, string commentBody)
        {
            JiraCommentObject comment = new NSSC.CRM.Jira.JiraModels.JiraCommentObject() { body = commentBody };

            var client = new RestClient($"https://neustylesoftware.atlassian.net/rest/api/2");
            var request = new RestRequest($"issue/{issueKey}/comment", Method.POST);
            client.Authenticator = new HttpBasicAuthenticator(Credential.Username, Credential.Password);

            request.AddJsonBody(comment);
            var result = client.Execute<JiraCommentObject>(request);

        }

        static void DeleteComment(string issueKey, string commentId)
        {            
            var client = new RestClient($"https://neustylesoftware.atlassian.net/rest/api/2");
            var request = new RestRequest($"issue/{issueKey}/comment/{commentId}", Method.DELETE);
            client.Authenticator = new HttpBasicAuthenticator(Credential.Username, Credential.Password);

            var result = client.Execute<JiraCommentObject>(request);
        }

        static void GetGroups()
        {
            var client = new RestClient($"https://neustylesoftware.atlassian.net/rest/api/2");
            var request = new RestRequest($"groups/picker", Method.GET);
            client.Authenticator = new HttpBasicAuthenticator(Credential.Username, Credential.Password);

            var result = client.Execute(request);
        }

        static void DownloadAttachment()
        {
            
            var client = new RestClient($"https://neustylesoftware.atlassian.net/secure");
            var request = new RestRequest($"attachment/10415/Client636285911310705788feeling_grateful-31.jpg", Method.GET);

            client.Authenticator = new HttpBasicAuthenticator(Credential.Username, Credential.Password);

            var response = client.Execute(request);

            var bytes = response.RawBytes;
            File.WriteAllBytes(@"d:\sdfd.jpg", bytes);

            //StreamWriter stream = new StreamWriter("d:\\sdas.jpg",true, Encoding.Unicode);
            //stream.Write(result.Content);

            

        }

    }
}
