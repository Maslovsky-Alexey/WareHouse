using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.AutharizationAPI
{
    public class HttpRefactor
    {
        // TODO: а стандартного UrlEncode для Core нет?
        public string EncodeUri(string uri)
        {
            return uri.Replace("/", "slash").Replace(":", "dvoetochie");
        }

        public string DecodeUri(string uri)
        {
            return uri.Replace("dvoetochie", ":").Replace("slash", "/");
        }
    }
}
