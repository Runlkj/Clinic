using Abp.AspNetCore.Mvc.Views;

namespace ClinicManager.Web.Views
{
    public abstract class ClinicManagerRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected ClinicManagerRazorPage()
        {
            LocalizationSourceName = ClinicManagerConsts.LocalizationSourceName;
        }
    }
}
