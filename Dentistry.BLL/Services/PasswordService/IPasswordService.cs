namespace Dentistry.BLL.Services.PasswordService
{
    public interface IPasswordService
    {
        byte[] HashPassword(string password, byte[] salt);
    }
}
