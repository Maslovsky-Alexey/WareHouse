using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.PollingEventManager.Models
{
    public class EventModel
    {
        public long Ticks { get; set; }

        public string DataType { get; set; }

        public object Data { get; set; }
    }
}
