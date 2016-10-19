using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.Model;

namespace WareHouse.Domain.Model
{
    public class ItemStatus : BaseModel
    {
        public string Name { get; set; }

        public virtual Status Status { get; set; }
    }
}
