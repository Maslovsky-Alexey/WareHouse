﻿using FluentValidation.Attributes;
using FluentValidation.Validators;

namespace WareHouse.Domain.Model
{
    public class Client : BaseModel
    {
        public string Name { get; set; }

        public string UserId { get; set; }
    }
}