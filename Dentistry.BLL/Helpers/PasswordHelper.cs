using System.Security.Cryptography;
using System.Text;

namespace Dentistry.BLL.Helpers
{
    public static class PasswordHelper
    {
        public static byte[] GenerateSalt()
        {
            const int saltLength = 64;
            byte[] salt = new byte[saltLength];

            var randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(salt);

            return salt;
        }

        public static string HashPassword(string password, byte[] salt)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltedPassword = new byte[salt.Length + passwordBytes.Length];

            using var sha256 = SHA256.Create();
            var hashedPassword = sha256.ComputeHash(saltedPassword);

            return Encoding.UTF8.GetString(hashedPassword);
        }
    }
}
