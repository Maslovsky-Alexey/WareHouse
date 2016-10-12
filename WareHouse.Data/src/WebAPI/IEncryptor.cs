using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public interface IEncryptor
    {
        string Key { get; set; }
        string VI { get; set; }


        string Encrypt(string text);

        string Decrypt(string text);
    }
}
