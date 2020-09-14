using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace ClinicManager
{
    [DependsOn(
        typeof(ClinicManagerCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ClinicManagerApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ClinicManagerApplicationModule).GetAssembly());
        }
    }
}