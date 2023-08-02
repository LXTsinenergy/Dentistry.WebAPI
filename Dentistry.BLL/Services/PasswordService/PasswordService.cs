using System.Security.Cryptography;
using System.Text;

namespace Dentistry.BLL.Services.PasswordService
{
    public class PasswordService : IPasswordService
    {
        public string HashPassword(string password, byte[] salt)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltedPassword = new byte[salt.Length + passwordBytes.Length];

            using var sha256 = SHA256.Create();
            var hashedPassword = sha256.ComputeHash(saltedPassword);

            return Encoding.UTF8.GetString(hashedPassword);
        }

        public byte[] GenerateSalt()
        {
            const int saltLength = 64;
            byte[] salt = new byte[saltLength];

            var randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(salt);

            return salt;
        }

        public string GenerateCode()
        {
            var random = new Random();
            var code = random.Next(10000, 100000);
            return code.ToString();
        }
    }
}
