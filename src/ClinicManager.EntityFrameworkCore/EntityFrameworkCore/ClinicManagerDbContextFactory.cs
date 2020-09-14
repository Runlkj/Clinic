using ClinicManager.Configuration;
using ClinicManager.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ClinicManager.EntityFrameworkCore
{
    /* This class is needed to run EF Core PMC commands. Not used anywhere else */
    public class ClinicManagerDbContextFactory : IDesignTimeDbContextFactory<ClinicManagerDbContext>
    {
        public ClinicManagerDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ClinicManagerDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DbContextOptionsConfigurer.Configure(
                builder,
                configuration.GetConnectionString(ClinicManagerConsts.ConnectionStringName)
            );

            return new ClinicManagerDbContext(builder.Options);
        }
    }
}