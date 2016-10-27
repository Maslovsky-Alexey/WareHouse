using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.Domain.Model.ViewModel
{
    public class SignInLogModel
    {
        public string UserName { get; set; }

        public DateTime DateTime { get; set; }

        public bool isEmployee { get; set; }

        public string FullName { get; set; }

        public override string ToString()
        {
            var role = isEmployee ? "Employee" : "Client";

            return $"{role}, UserName: {UserName}, FullName: {FullName}, DateTime: {DateTime.ToString()}";
        }
    }
}
