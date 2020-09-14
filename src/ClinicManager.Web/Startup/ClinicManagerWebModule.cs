using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ClinicManager.Configuration;
using ClinicManager.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;

namespace ClinicManager.Web.Startup
{
    [DependsOn(
        typeof(ClinicManagerApplicationModule), 
        typeof(ClinicManagerEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class ClinicManagerWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public ClinicManagerWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(ClinicManagerConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<ClinicManagerNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(ClinicManagerApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ClinicManagerWebModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(ClinicManagerWebModule).Assembly);
        }
    }
}