using Microsoft.EntityFrameworkCore;

namespace ClinicManager.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<ClinicManagerDbContext> dbContextOptions, 
            string connectionString
            )
        {
            /* This is the single point to configure DbContextOptions for ClinicManagerDbContext */
            dbContextOptions.UseSqlServer(connectionString);
        }
    }
}
