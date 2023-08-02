namespace Dentistry.BLL.Services.PasswordService
{
    public interface IPasswordService
    {
        string HashPassword(string password, byte[] salt);
        byte[] GenerateSalt();
        string GenerateCode();
    }
}
