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
using xNet;

namespace WareHouse.FileCheckerService.APIMediator.WebRequestHelper
{
    public class WebRequestHelper : IWebRequestHelper
    {
        private string baseUri;

        public WebRequestHelper(string baseUri)
        {
            this.baseUri = baseUri;
        }

        public HttpResponse Post(string action, string content, string contentType, string authorizationToken)
        {
            using (var request = new HttpRequest(baseUri))
            {
                if (!String.IsNullOrEmpty(authorizationToken))
                    request.AddHeader("Authorization", authorizationToken);

                request.IgnoreProtocolErrors = true;

                request
                   .Post(action, content, contentType)
                   .ToString();

                return request.Response;
            }            
        }

        public HttpResponse Get(string action, string authorizationToken, params KeyValuePair<string, string>[] queryParams)
        {
            using (var request = new HttpRequest(baseUri))
            {
                request.AddHeader("Authorization", authorizationToken);

                request.IgnoreProtocolErrors = true;

                foreach (var param in queryParams)
                    request.AddUrlParam(param.Key, param.Value);

                request.Get(action).ToString();

                return request.Response;
            }
        }       
    }
}
