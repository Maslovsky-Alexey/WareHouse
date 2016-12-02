using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse.FileCheckerService.Models
{
    public class ChangeModel : BaseModel
    {
        public string FullPath { get; set; }

        public DateTime LastChange { get; set; }
    }
}
