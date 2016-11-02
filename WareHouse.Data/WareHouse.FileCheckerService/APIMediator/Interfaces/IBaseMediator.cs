using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse.FileCheckerService.APIMediator.Interfaces
{
    public interface IBaseMediator
    {
        HttpWebResponse SendRequest(string uri, string type, string body, string contentType, string authorizationToken);
    }
}
