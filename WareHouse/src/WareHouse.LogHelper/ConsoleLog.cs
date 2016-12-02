using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.LogHelper
{
    public class ConsoleLog : ILog
    {
        public ConsoleLog()
        {
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void Log(string text)
        {
            Console.WriteLine(text);
        }
    }
}
