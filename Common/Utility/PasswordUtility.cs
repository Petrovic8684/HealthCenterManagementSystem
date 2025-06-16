using System;
using System.Security.Cryptography;
using System.Text;

namespace Common.Config
{
    public static class PasswordUtility
    {
        private const int saltSize = 16;
        private const int keySize = 32;
        private const int iterations = 10000;

        public static string HashPassword(string password)
        {
            using var algorithm = new Rfc2898DeriveBytes(password, saltSize, iterations, HashAlgorithmName.SHA256);
            var salt = algorithm.Salt;
            var key = algorithm.GetBytes(keySize);

            var hashBytes = new byte[saltSize + keySize];
            Buffer.BlockCopy(salt, 0, hashBytes, 0, saltSize);
            Buffer.BlockCopy(key, 0, hashBytes, saltSize, keySize);

            return Convert.ToBase64String(hashBytes);
        }

        public static bool VerifyPassword(string password, string storedHash)
        {
            var hashBytes = Convert.FromBase64String(storedHash);

            var salt = new byte[saltSize];
            Buffer.BlockCopy(hashBytes, 0, salt, 0, saltSize);

            var key = new byte[keySize];
            Buffer.BlockCopy(hashBytes, saltSize, key, 0, keySize);

            using var algorithm = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256);
            var keyToCheck = algorithm.GetBytes(keySize);

            return CryptographicOperations.FixedTimeEquals(key, keyToCheck);
        }
    }
}