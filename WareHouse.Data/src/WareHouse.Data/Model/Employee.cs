﻿namespace WareHouse.Data.Model
{
    public class Employee : BaseModel
    {
        public string Name { get; set; }


        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}