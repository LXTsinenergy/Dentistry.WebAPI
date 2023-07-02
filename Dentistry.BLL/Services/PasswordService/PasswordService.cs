using System.Security.Cryptography;
using System.Text;

namespace Dentistry.BLL.Services.PasswordService
{
    public class PasswordService : IPasswordService
    {
        public byte[] HashPassword(string password, byte[] salt)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltedPassword = new byte[salt.Length + passwordBytes.Length];

            using var sha256 = SHA256.Create();
            return sha256.ComputeHash(saltedPassword);
        }

        public byte[] GenerateSalt()
        {
            const int saltLength = 64;
            byte[] salt = new byte[saltLength];

            var randomNumberGeneratot = RandomNumberGenerator.Create();
            randomNumberGeneratot.GetBytes(salt);

            return salt;
        }
    }
}
