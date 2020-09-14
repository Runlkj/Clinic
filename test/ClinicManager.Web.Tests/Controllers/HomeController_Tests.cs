using System.Threading.Tasks;
using ClinicManager.Web.Controllers;
using Shouldly;
using Xunit;

namespace ClinicManager.Web.Tests.Controllers
{
    public class HomeController_Tests: ClinicManagerWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
