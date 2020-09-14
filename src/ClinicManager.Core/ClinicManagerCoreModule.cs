using Abp.Modules;
using Abp.Reflection.Extensions;
using ClinicManager.Localization;

namespace ClinicManager
{
    public class ClinicManagerCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            ClinicManagerLocalizationConfigurer.Configure(Configuration.Localization);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ClinicManagerCoreModule).GetAssembly());
        }
    }
}