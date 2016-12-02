using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.AutharizationAPI.PasswordGenerators
{
    public class PasswordGenerator : IPasswordGenerator
    {
        public string GeneratePassword(int minLength, int maxLength)
        {
            var result = "";

            var rnd = new Random();
            var length = rnd.Next(minLength, maxLength);

            for (int i = 0; i < length; i++)
            {
                result += (rnd.Next(2) == 0 ? (char)rnd.Next(48, 57) : (char)rnd.Next(97, 122));
            }

            return result;
        }
    }
}
