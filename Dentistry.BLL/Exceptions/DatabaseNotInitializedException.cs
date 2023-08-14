using Dentistry.DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Pqc.Crypto.Lms;

namespace Dentistry.BLL.Exceptions
{
    public class DatabaseNotInitializedException<TContext> : Exception
        where TContext : DbContext
    {
        public DatabaseNotInitializedException()
            : base($"Database \"{typeof(TContext)}\"  has not been initialized.") { }
    }
}
