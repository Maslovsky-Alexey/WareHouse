using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.LogHelper
{
    public interface ILog
    {
        void Log(string text);

        void Clear();
    }
}
