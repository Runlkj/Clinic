using Abp.Application.Services;

namespace ClinicManager
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class ClinicManagerAppServiceBase : ApplicationService
    {
        protected ClinicManagerAppServiceBase()
        {
            LocalizationSourceName = ClinicManagerConsts.LocalizationSourceName;
        }
    }
}