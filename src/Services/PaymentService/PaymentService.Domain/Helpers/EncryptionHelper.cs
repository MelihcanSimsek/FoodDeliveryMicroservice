using System.Security.Cryptography;
using System.Text;


namespace PaymentService.Domain.Helpers
{
    public static class EncryptionHelper
    {
        private static readonly string EncryptionKey = "ySf3Z7n4Udtp3zbrFm7r/fWYTpoXB6liYfXtYqUBo2+fXspyZ3IH72PF5rZtEoVt";

        public static string Encrypt(string text)
        {
            using var aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(EncryptionKey);
            aes.GenerateIV();
            using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using var ms = new MemoryStream();
            ms.Write(aes.IV, 0, aes.IV.Length); 
            using var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
            using var sw = new StreamWriter(cs);
            sw.Write(text);

            return Convert.ToBase64String(ms.ToArray());
        }

        public static string Decrypt(string cipherText)
        {
            var fullCipher = Convert.FromBase64String(cipherText);
            using var aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(EncryptionKey);

            var iv = new byte[16];
            Array.Copy(fullCipher, 0, iv, 0, iv.Length);
            aes.IV = iv;

            using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using var ms = new MemoryStream(fullCipher, iv.Length, fullCipher.Length - iv.Length);
            using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using var sr = new StreamReader(cs);
            return sr.ReadToEnd();
        }
    }
}
