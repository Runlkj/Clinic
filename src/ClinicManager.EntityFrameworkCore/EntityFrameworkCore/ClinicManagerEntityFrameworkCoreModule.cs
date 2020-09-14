using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace ClinicManager.EntityFrameworkCore
{
    [DependsOn(
        typeof(ClinicManagerCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class ClinicManagerEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ClinicManagerEntityFrameworkCoreModule).GetAssembly());
        }
    }
}