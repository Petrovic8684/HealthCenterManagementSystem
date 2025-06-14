using System;
using System.Security.Cryptography;
using System.Text;

namespace Common.Config
{
    public static class PasswordUtility
    {
        private const int SaltSize = 16;
        private const int KeySize = 32;
        private const int Iterations = 10000;

        public static string HashPassword(string password)
        {
            using var algorithm = new Rfc2898DeriveBytes(password, SaltSize, Iterations, HashAlgorithmName.SHA256);
            var salt = algorithm.Salt;
            var key = algorithm.GetBytes(KeySize);

            var hashBytes = new byte[SaltSize + KeySize];
            Buffer.BlockCopy(salt, 0, hashBytes, 0, SaltSize);
            Buffer.BlockCopy(key, 0, hashBytes, SaltSize, KeySize);

            return Convert.ToBase64String(hashBytes);
        }

        public static bool VerifyPassword(string password, string storedHash)
        {
            var hashBytes = Convert.FromBase64String(storedHash);

            var salt = new byte[SaltSize];
            Buffer.BlockCopy(hashBytes, 0, salt, 0, SaltSize);

            var key = new byte[KeySize];
            Buffer.BlockCopy(hashBytes, SaltSize, key, 0, KeySize);

            using var algorithm = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
            var keyToCheck = algorithm.GetBytes(KeySize);

            return CryptographicOperations.FixedTimeEquals(key, keyToCheck);
        }
    }
}