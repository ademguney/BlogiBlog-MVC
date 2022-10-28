using System.Security.Cryptography;
using System.Text;

namespace Core.Application.Security.Hashing
{
    public static class EnDecode
    {
        public static void Encrypt(string plainText, out byte[] plainTextHash, out byte[] plainTextSalt)
        {
            using var hmac = new HMACSHA512();
            plainTextSalt = hmac.Key;
            plainTextHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(plainText));
        }

        public static bool Decrypt(string plainText, byte[] plainTextHash, byte[] plainTextSalt)
        {
            using var hmac = new HMACSHA512(plainTextSalt);
            byte[] computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(plainText));
            for (int i = 0; i < computeHash.Length; i++)
            {
                if (computeHash[i] != plainTextHash[i])
                    return false;
            }
            return true;
        }
    }
}
