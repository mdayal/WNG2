using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace CT.Utility.Helpers
{
    public static class PasswordSecurityService
    {
        private static readonly string AllowedChars ="0123456789";
        private static readonly int PasswordLength = 4;
        private static readonly string PasswordSalt = "29A9C6350D9969AEB1F52E50D8B4BBEBC53B2E87AF05DA95D03C30631B947D1BAA2477635D89E977E8BB5736A1587DD8B3FDC43939FD767CFE8A9C91D24EA79D";

        static PasswordSecurityService()
        {
            PasswordSalt = ConfigurationManager.AppSettings["PasswordSalt"];
            PasswordLength = int.Parse(ConfigurationManager.AppSettings["PasswordLength"]);
            AllowedChars = ConfigurationManager.AppSettings["AllowedTemporaryPasswordChars"];
        }

        public static string GenerateTemporaryPassword()
        {
            var chars = new char[PasswordLength];
            var rd = new Random();

            for (var i = 0; i < PasswordLength; i++)
            {
                chars[i] = AllowedChars[rd.Next(0, AllowedChars.Length)];
            }

            return new string(chars);
        }

        public static  bool ValidatePlainTextPassword(string plainTextPassword, string hashedPassword)
        {
            return HashPassword(plainTextPassword) == hashedPassword;
        }

        public static string HashPassword(string plainTextPassword)
        {
            var hash1 = HashText(
                plainTextPassword,
                PasswordSalt,
                new SHA1CryptoServiceProvider());

            return HashText(
                hash1 + plainTextPassword + hash1,
                PasswordSalt,
                new SHA1CryptoServiceProvider());

        }

        private static string HashText(string text, string salt, HashAlgorithm hasher)
        {
            var hashedText = Convert.ToBase64String(
                hasher.ComputeHash(
                    Encoding.UTF8.GetBytes(string.Concat(text, salt))
                    )
                );
            hasher.Clear();
            return hashedText;
        }

    }
}