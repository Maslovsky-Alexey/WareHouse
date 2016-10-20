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