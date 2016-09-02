using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.Data.Model
{
    public interface IItem
    {
        string Name { get; set; }
        
        int Count { get; set; }
    }
}
