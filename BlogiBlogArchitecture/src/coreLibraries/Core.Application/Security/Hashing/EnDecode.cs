using System.Security.Cryptography;

namespace Core.Application.Security.Hashing
{
    public static class EnDecode
    {
        private static readonly int _saltSize = 32;

        public static string Encrypt(string plainText, string key)
        {
            using var keyDerivationFunction = new Rfc2898DeriveBytes(key, _saltSize);
            byte[] saltBytes = keyDerivationFunction.Salt;
            byte[] keyBytes = keyDerivationFunction.GetBytes(32);
            byte[] ivBytes = keyDerivationFunction.GetBytes(16);

            using var aesManaged = new AesManaged();
            aesManaged.KeySize = 256;

            using var encryptor = aesManaged.CreateEncryptor(keyBytes, ivBytes);
            MemoryStream memoryStream = null;
            CryptoStream cryptoStream = null;

            return WriteMemoryStream(plainText, ref saltBytes, encryptor, ref memoryStream, ref cryptoStream);
        }
        public static string Decrypt(string ciphertext, string key)
        {

            var allTheBytes = Convert.FromBase64String(ciphertext);
            var saltBytes = allTheBytes.Take(_saltSize).ToArray();
            var ciphertextBytes = allTheBytes.Skip(_saltSize).Take(allTheBytes.Length - _saltSize).ToArray();

            using var keyDerivationFunction = new Rfc2898DeriveBytes(key, saltBytes);
            var keyBytes = keyDerivationFunction.GetBytes(32);
            var ivBytes = keyDerivationFunction.GetBytes(16);

            return DecryptWithAES(ciphertextBytes, keyBytes, ivBytes);
        }

        private static string WriteMemoryStream(string plainText, ref byte[] saltBytes, ICryptoTransform encryptor, ref MemoryStream memoryStream, ref CryptoStream cryptoStream)
        {
            try
            {
                memoryStream = new MemoryStream();

                try
                {
                    cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);

                    using var streamWriter = new StreamWriter(cryptoStream);
                    streamWriter.Write(plainText);
                }
                finally
                {
                    if (cryptoStream != null)
                    {
                        cryptoStream.Dispose();
                    }
                }

                var cipherTextBytes = memoryStream.ToArray();
                Array.Resize(ref saltBytes, saltBytes.Length + cipherTextBytes.Length);
                Array.Copy(cipherTextBytes, 0, saltBytes, _saltSize, cipherTextBytes.Length);
                return Convert.ToBase64String(saltBytes);
            }
            finally
            {
                if (memoryStream != null)
                {
                    memoryStream.Dispose();
                }
            }
        }

        private static string DecryptWithAES(byte[] ciphertextBytes, byte[] keyBytes, byte[] ivBytes)
        {
            using var aesManaged = new AesManaged();
            using var decryptor = aesManaged.CreateDecryptor(keyBytes, ivBytes);
            MemoryStream memoryStream = null;
            CryptoStream cryptoStream = null;
            StreamReader streamReader = null;

            try
            {
                memoryStream = new MemoryStream(ciphertextBytes);
                cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
                streamReader = new StreamReader(cryptoStream);

                return streamReader.ReadToEnd();
            }
            finally
            {
                if (memoryStream != null)
                {
                    memoryStream.Dispose();
                    memoryStream = null;
                }
            }
        }
    }
}
