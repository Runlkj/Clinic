using System.Reflection;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.TestBase;
using ClinicManager.EntityFrameworkCore;
using Castle.MicroKernel.Registration;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicManager.Tests
{
    [DependsOn(
        typeof(ClinicManagerApplicationModule),
        typeof(ClinicManagerEntityFrameworkCoreModule),
        typeof(AbpTestBaseModule)
        )]
    public class ClinicManagerTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
            SetupInMemoryDb();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ClinicManagerTestModule).GetAssembly());
        }

        private void SetupInMemoryDb()
        {
            var services = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase();

            var serviceProvider = WindsorRegistrationHelper.CreateServiceProvider(
                IocManager.IocContainer,
                services
            );

            var builder = new DbContextOptionsBuilder<ClinicManagerDbContext>();
            builder.UseInMemoryDatabase("Test").UseInternalServiceProvider(serviceProvider);

            IocManager.IocContainer.Register(
                Component
                    .For<DbContextOptions<ClinicManagerDbContext>>()
                    .Instance(builder.Options)
                    .LifestyleSingleton()
            );
        }
    }
}