using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.LogHelper
{
    interface ILog
    {
        void Log(string text);

        void Clear();
    }
}
