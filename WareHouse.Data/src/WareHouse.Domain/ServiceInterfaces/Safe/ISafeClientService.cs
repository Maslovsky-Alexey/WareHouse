﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Domain.Model;
using WareHouse.Domain.Model.ViewModel;

namespace WareHouse.Domain.ServiceInterfaces.Safe
{
    public interface ISafeClientService
    {
        Task<Client> GetClientByName(string name, bool ignoreCase);

        Task<Client> GetClientByIdentityId(string identityId);
    }
}
