using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.AutharizationAPI.PasswordGenerators
{
    public interface IPasswordGenerator
    {
        string GeneratePassword(int minLength, int maxLength);
    }
}
