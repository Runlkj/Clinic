using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.EntityFrameworkCore
{
    public class ClinicManagerDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...

        public ClinicManagerDbContext(DbContextOptions<ClinicManagerDbContext> options) 
            : base(options)
        {

        }
    }
}
