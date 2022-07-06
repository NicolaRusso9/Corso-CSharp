using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CorsoCSharp
{
    static class _28_Encryption
    {
        #region AES
        // salt must be at least 8 bytes, we will use 16 bytes
        private static readonly byte[] salt = Encoding.Unicode.GetBytes("7BANANAS");

        // iteretion must be at least 100, we will use 2000
        private static readonly int iteretions = 2_000;

        public static string Encrypt(string plainText, string password)
        {
            byte[] encryptedBytes;
            byte[] plainTextBytes = Encoding.Unicode.GetBytes(plainText);

            var aes = Aes.Create();

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iteretions);

            aes.Key = pbkdf2.GetBytes(32);      // set a 256 bit keys
            aes.IV = pbkdf2.GetBytes(16);       // set a 128 bit IV

            using(var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(plainTextBytes, 0, plainTextBytes.Length);
                }

                encryptedBytes = ms.ToArray();
            }

            return Convert.ToBase64String(encryptedBytes);
        }


        public static string Decrypt(string cryptoText, string password)
        {
            byte[] encryptedBytes;
            byte[] cryptoBytes = Convert.FromBase64String(cryptoText);

            var aes = Aes.Create();

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iteretions);

            aes.Key = pbkdf2.GetBytes(32);      // set a 256 bit keys
            aes.IV = pbkdf2.GetBytes(16);       // set a 128 bit IV

            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cryptoBytes, 0, cryptoBytes.Length);
                }

                encryptedBytes = ms.ToArray();
            }

            return Encoding.Unicode.GetString(encryptedBytes);
        }
        #endregion

        #region SHA256
        public class User
        {
            public string Name { get; set; }
            public string Salt { get; set; }
            public string SaltedHashedPassword { get; set; }

            private static Dictionary<string, User> Users = new Dictionary<string, User>();

            private static User Register(string username, string password)
            {
                var rng = RandomNumberGenerator.Create();
                var saltBytes = new byte[16];
                rng.GetBytes(saltBytes);
                string saltText = Convert.ToBase64String(saltBytes);

                var saltedHasehdPassword = SaltAndHashPassword(password, saltText);

                var user = new User
                {
                    Name = username,
                    Salt = saltText,
                    SaltedHashedPassword = saltedHasehdPassword
                };

                Users.Add(user.Name, user);
                return user;
            }

            public static bool CheckPassword(string username, string password)
            {
                if (!Users.ContainsKey(username))
                {
                    return false;
                }
                var user = Users[username];

                var saltedhashedPassword = SaltAndHashPassword(password, user.Salt);

                return (saltedhashedPassword == user.SaltedHashedPassword);
            }

            private static string SaltAndHashPassword(string password, string salt)
            {
                var sha = SHA256.Create();
                var saltedPassword = password + salt;
                return Convert.ToBase64String(sha.ComputeHash(Encoding.Unicode.GetBytes(saltedPassword)));
            }
        }
        #endregion
    }
}
