using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI
{
    public class TokenEncryptor : IEncryptor
    {
        private static TokenEncryptor tokenEncryptor;

        private Aes cipher;
        public string Key { get; set; } = "";
        public string VI { get; set; } = "";

        private TokenEncryptor()
        {
            cipher = Aes.Create();
        }

        public static TokenEncryptor Instance
        {
            get
            {
                if (tokenEncryptor == null)
                    tokenEncryptor = new TokenEncryptor();

                return tokenEncryptor;
            }
        }

        public string Encrypt(string text)
        {
            ICryptoTransform t = cipher.CreateEncryptor(Encoding.UTF8.GetBytes(Key), Encoding.UTF8.GetBytes(VI));
            
            byte[] textInBytes = Encoding.UTF8.GetBytes(text);
            byte[] result = t.TransformFinalBlock(textInBytes, 0, textInBytes.Length);
            return Convert.ToBase64String(result);
        }

        public string Decrypt(string text)
        {           
            ICryptoTransform t = cipher.CreateDecryptor(Encoding.UTF8.GetBytes(Key), Encoding.UTF8.GetBytes(VI));

            byte[] textInBytes = Convert.FromBase64String(text);
            byte[] result = t.TransformFinalBlock(textInBytes, 0, textInBytes.Length);
            return Encoding.UTF8.GetString(result);
        }
    }
}
