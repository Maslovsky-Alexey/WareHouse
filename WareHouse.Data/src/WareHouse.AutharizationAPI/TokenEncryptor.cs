using System;
using System.Security.Cryptography;
using System.Text;

namespace WareHouse.AutharizationAPI
{
    public class TokenEncryptor : IEncryptor
    {
        private static TokenEncryptor tokenEncryptor;

        private readonly Aes cipher;

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

        public string Key { get; set; } = "";
        public string VI { get; set; } = "";

        public string Encrypt(string text)
        {
            var t = cipher.CreateEncryptor(Encoding.UTF8.GetBytes(Key), Encoding.UTF8.GetBytes(VI));

            var textInBytes = Encoding.UTF8.GetBytes(text);
            var result = t.TransformFinalBlock(textInBytes, 0, textInBytes.Length);
            return Convert.ToBase64String(result);
        }

        public string Decrypt(string text)
        {
            var t = cipher.CreateDecryptor(Encoding.UTF8.GetBytes(Key), Encoding.UTF8.GetBytes(VI));

            var textInBytes = Convert.FromBase64String(text);
            var result = t.TransformFinalBlock(textInBytes, 0, textInBytes.Length);

            text = text.Replace("tochka", ".");
            return Encoding.UTF8.GetString(result);
        }
    }
}