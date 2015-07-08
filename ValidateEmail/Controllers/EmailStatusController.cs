using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Script.Serialization;
using System.Xml;
using ValidateEmail.Models;

namespace ValidateEmail.Controllers
{
    [EnableCors(origins: "chrome-extension://nakkedmlflejnoifdhdfcalphdmogddm", headers: "*", methods: "get")]
    public class EmailStatusController : ApiController
    {
        // GET: api/EmailStatus
        public HttpResponseMessage Get(string Email)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            
            string serviceUrl = "https://bpi.briteverify.com/emails.json?address=" + Email + "&apikey=2194f75a-34ac-49d5-97c8-e321e508e58f";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceUrl);
            request.Method = "GET";
            request.Accept = "application/json; charset=UTF-8";
            
            var httpResponse = (HttpWebResponse)request.GetResponse();
            EmailStatus EmailStatus = null;
            string rt = string.Empty;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var responstText = streamReader.ReadToEnd();
                rt = responstText;
                EmailStatus = serializer.Deserialize<EmailStatus>(responstText);
            }

            HttpResponseMessage HttpResponseMsg = Request.CreateResponse<EmailStatus>(HttpStatusCode.OK, EmailStatus);

            return HttpResponseMsg;
        }

        // GET: api/EmailStatus/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/EmailStatus
        public void Post(Account Account)
        {
            var rrr = Request.Headers.GetValues("Origin");   
        }

        // PUT: api/EmailStatus/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/EmailStatus/5
        public void Delete(int id)
        {
        }
    }
}
