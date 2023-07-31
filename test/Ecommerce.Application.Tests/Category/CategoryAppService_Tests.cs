using Ecommerce.Interface;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Xunit;

namespace Ecommerce.Category
{
    public class CategoryAppService_Tests: EcommerceApplicationTestBase
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoryAppService_Tests(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }


        [Fact]
        public async Task Should_Get_Category_List()
        {
            //Act
            var output = await _categoryAppService.GetListAsync(new PagedAndSortedResultRequestDto());
            //Assert
            
            output.Items.ShouldContain(
            x => x.Name.Contains("Monitors")
            );
        }
    }
}
