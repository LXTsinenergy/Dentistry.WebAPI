namespace Dentistry.DAL.DataContext
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context) =>
            context.Database.EnsureCreated();
    }
}
