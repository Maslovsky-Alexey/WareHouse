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

namespace WareHouse.FileCheckerService.APIMediator
{
    public abstract class BaseMediator<T> : IMediator<T>
        where T : class
    {
        private string url;
        private string additionAction;

        public BaseMediator(string url, string additionAction)
        {
            this.url = url;
            this.additionAction = additionAction;
        }

        protected void SendItem(string action, T item)
        {
            SendPostRequest(url + "/" + action, JsonConvert.SerializeObject(item));
        }

        protected HttpWebResponse SendPostRequest(string uri, string content)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.ContentType = "application/json; charset=UTF-8";
            httpWebRequest.Headers.Add("Authorization", "Bearer WIwqABRAoB/4DGjaTNY6TQ==");
            httpWebRequest.Method = "POST";

            WriteJsonToHttpWebReques(httpWebRequest, content);

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

        public void AddItem(T item)
        {
            SendItem(additionAction, item);
        }
    }
}
