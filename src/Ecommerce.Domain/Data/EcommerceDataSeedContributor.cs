using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Ecommerce.Data
{
    public class EcommerceDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Category, Guid> _categoryRepository;

        public EcommerceDataSeedContributor(
            IRepository<Category, Guid> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _categoryRepository.CountAsync() > 0)
            {
                return;
            }
            var monitors = new Category { Name = "Monitors" };
            var printers = new Category { Name = "Printers" };
            await _categoryRepository
                .InsertManyAsync(new[] { monitors, printers });
        }
    }
}
