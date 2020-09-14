using ClinicManager.EntityFrameworkCore;

namespace ClinicManager.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly ClinicManagerDbContext _context;

        public TestDataBuilder(ClinicManagerDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
        }
    }
}