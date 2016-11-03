using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using xNet;

namespace WareHouse.FileCheckerService.APIMediator.WebRequestHelper
{
    public interface IWebRequestHelper
    {
        HttpResponse Post(string action, string content, string contentType, string authorizationToken);

        HttpResponse Get(string action, string authorizationToken, params KeyValuePair<string, string>[] queryParams);
    }
}
