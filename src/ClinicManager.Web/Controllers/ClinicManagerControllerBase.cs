using Abp.AspNetCore.Mvc.Controllers;

namespace ClinicManager.Web.Controllers
{
    public abstract class ClinicManagerControllerBase: AbpController
    {
        protected ClinicManagerControllerBase()
        {
            LocalizationSourceName = ClinicManagerConsts.LocalizationSourceName;
        }
    }
}