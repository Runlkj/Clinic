using System;
using System.Threading.Tasks;
using Abp.TestBase;
using ClinicManager.EntityFrameworkCore;
using ClinicManager.Tests.TestDatas;

namespace ClinicManager.Tests
{
    public class ClinicManagerTestBase : AbpIntegratedTestBase<ClinicManagerTestModule>
    {
        public ClinicManagerTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<ClinicManagerDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<ClinicManagerDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<ClinicManagerDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<ClinicManagerDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<ClinicManagerDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<ClinicManagerDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<ClinicManagerDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<ClinicManagerDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
