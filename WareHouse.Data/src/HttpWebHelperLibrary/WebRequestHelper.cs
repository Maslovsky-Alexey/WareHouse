using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Collections.Specialized;
using WareHouse.LogHelper;


namespace HttpWebHelperLibrary
{
    public class WebRequestHelper : IWebRequestHelper
    {
        private readonly ILog log;

        public WebRequestHelper(ILog log)
        {
            this.log = log;
        }

        public async Task<WebResponse> SendRequest(string uri, string type, string body)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);

            httpWebRequest.ContentType = "application/json; charset=UTF-8";

            httpWebRequest.Method = type;

            if (!string.IsNullOrEmpty(body))
                await WriteJsonToHttpWebReques(httpWebRequest, body);

            return await GetResponse(httpWebRequest);
        }

        private async Task WriteJsonToHttpWebReques(HttpWebRequest httpWebRequest, string content)
        {
            using (var streamWriter = new StreamWriter(await httpWebRequest.GetRequestStreamAsync()))
            {
                streamWriter.Write(content);
                streamWriter.Flush();
            }
        }

        private async Task<WebResponse> GetResponse(HttpWebRequest httpWebRequest)
        {
            WebResponse httpResponse = null;

            try
            {
                httpResponse = await httpWebRequest.GetResponseAsync();
            }
            catch (Exception e)
            {
                log.Log(e.Message);
            }

            return httpResponse;
        }

        public T GetObjectFromResponse<T>(WebResponse httpResponse)
        {
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(result);
            }
        }
    }
}
