using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI
{
    public static class TokenEncryptor
    {
        private static Aes cipher;

        public static string Encrypt(string text)
        {
            ICryptoTransform t = cipher.CreateEncryptor();

            byte[] textInBytes = Encoding.UTF8.GetBytes(text);
            byte[] result = t.TransformFinalBlock(textInBytes, 0, textInBytes.Length);
            return Convert.ToBase64String(result);
        }

        public static string Decrypt(string text)
        {           
            ICryptoTransform t = cipher.CreateDecryptor();

            byte[] textInBytes = Convert.FromBase64String(text);
            byte[] result = t.TransformFinalBlock(textInBytes, 0, textInBytes.Length);
            return Encoding.UTF8.GetString(result);
        }

        static TokenEncryptor()
        {
            cipher = Aes.Create();
        }
    }
}
