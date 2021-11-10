using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace KinopoiskAPI.Utils.Hasher
{
    public class Hasher
    {
        public static byte[] GetSalt()
        {
            var salt = new byte[128 / 8];
            using var rngCsp = new RNGCryptoServiceProvider();
            rngCsp.GetNonZeroBytes(salt);
            return salt;
        }

        public static string GetHash(string password, byte[] salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 256 / 8
                ));
        }

        public static bool CheckPassword(string password, string hashedPassword, byte[] salt)
        {
            var passwordHash = GetHash(password, salt);
            return passwordHash.Equals(hashedPassword);
        }
    }
}