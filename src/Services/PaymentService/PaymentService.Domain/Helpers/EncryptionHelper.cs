using System.Security.Cryptography;
using System.Text;


namespace PaymentService.Domain.Helpers
{
    public static class EncryptionHelper
    {
        private static readonly string EncryptionKey = "bXlQYXNzd29yZDEyMzQ1Njc4OQ";
        private static readonly byte[] EncryptionKeyBytes = Convert.FromBase64String(EncryptionKey);

        static EncryptionHelper()
        {
            if (EncryptionKeyBytes.Length != 16 && EncryptionKeyBytes.Length != 24 && EncryptionKeyBytes.Length != 32)
            {
                throw new ArgumentException("Encryption key must be 16, 24, or 32 bytes long.");
            }
            Console.WriteLine($"Encryption Key Length: {EncryptionKeyBytes.Length}");
        }

        public static string Encrypt(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("Input text cannot be null or empty.", nameof(text));
            }

            using var aes = Aes.Create();
            aes.Key = EncryptionKeyBytes;
            aes.GenerateIV();

            using var ms = new MemoryStream();
            ms.Write(aes.IV, 0, aes.IV.Length);  
            using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            using var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
            using var sw = new StreamWriter(cs);
            sw.Write(text);
            sw.Flush();
            cs.FlushFinalBlock();

            return Convert.ToBase64String(ms.ToArray());
        }

        public static string Decrypt(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
            {
                throw new ArgumentException("Cipher text cannot be null or empty.", nameof(cipherText));
            }

            var fullCipher = Convert.FromBase64String(cipherText);

            if (fullCipher.Length < 16)
            {
                throw new CryptographicException("Invalid ciphertext: too short.");
            }

            using var aes = Aes.Create();
            aes.Key = EncryptionKeyBytes;

            var iv = new byte[16]; 
            Array.Copy(fullCipher, 0, iv, 0, iv.Length);
            aes.IV = iv;

            using var ms = new MemoryStream(fullCipher, iv.Length, fullCipher.Length - iv.Length);
            using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using var sr = new StreamReader(cs);
            return sr.ReadToEnd();
        }
    }


}
