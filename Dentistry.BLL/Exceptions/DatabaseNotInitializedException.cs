using Dentistry.DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Pqc.Crypto.Lms;

namespace Dentistry.BLL.Exceptions
{
    public class DatabaseNotInitializedException : Exception
    {
        public DatabaseNotInitializedException(string contextName)
            : base($"Database \"{contextName}\"  has not been initialized.") { }
    }
}
