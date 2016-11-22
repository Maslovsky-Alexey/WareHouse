using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


namespace HttpWebHelperLibrary
{
    public interface IWebRequestHelper
    {
        Task<WebResponse> SendRequest(string uri, string type, string body);

        T GetObjectFromResponse<T>(WebResponse httpResponse);
    }
}
