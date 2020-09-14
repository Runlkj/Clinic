using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ClinicManager.Web.Startup;
namespace ClinicManager.Web.Tests
{
    [DependsOn(
        typeof(ClinicManagerWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class ClinicManagerWebTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ClinicManagerWebTestModule).GetAssembly());
        }
    }
}