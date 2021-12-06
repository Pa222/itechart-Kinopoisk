using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;

namespace KinopoiskAPI.Utils.Hasher
{
    public class Hasher
    {
        public static byte[] GetSalt()
        {
            var salt = new byte[16];
            using var rngCsp = new RNGCryptoServiceProvider();
            rngCsp.GetNonZeroBytes(salt);
            return salt;
        }

        public static string GetHash(string password, byte[] salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password,
                    salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 32
                ));
        }

        public static bool CheckPassword(string password, string hashedPassword, byte[] salt)
        {
            var passwordHash = GetHash(password, salt);
            return passwordHash.Equals(hashedPassword);
        }
    }
}