using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using WareHouse.FileCheckerService.APIMediator.Interfaces;
using System.Collections.Specialized;

namespace WareHouse.FileCheckerService.APIMediator
{
    public class BaseMediator : IBaseMediator
    {

        public BaseMediator()
        {
        }

        public HttpWebResponse SendRequest(string uri, string type, string body, string contentType, string authorizationToken)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);

            httpWebRequest.ContentType = contentType;

            httpWebRequest.Headers.Add("Authorization", "Bearer WIwqABRAoB/4DGjaTNY6TQ==");

            httpWebRequest.Method = type;

            if (body != null)
                WriteJsonToHttpWebReques(httpWebRequest, body);

            return GetResponse(httpWebRequest);
        }

        private void WriteJsonToHttpWebReques(HttpWebRequest httpWebRequest, string content)
        {
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(content);
                streamWriter.Flush();
                streamWriter.Close();
            }
        }

        private HttpWebResponse GetResponse(HttpWebRequest httpWebRequest)
        {
            HttpWebResponse httpResponse = null;

            try
            {
                httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
            }
            catch
            {

            }

            return httpResponse;
        }
    }
}
