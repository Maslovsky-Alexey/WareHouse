using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.MyEventStream
{
    public class KeyValue
    {
        public string Key { get; set; }

        public object Value { get; set; }

        public KeyValue(string key, object value)
        {
            Key = key;
            Value = value;
        }
    }
}
