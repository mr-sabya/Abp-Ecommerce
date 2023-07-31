using Ecommerce.ModelDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Ecommerce.Interface
{
    public interface ICategoryAppService : IApplicationService
    {
        //get all data list
        Task<PagedResultDto<CategoryDto>> GetListAsync(PagedAndSortedResultRequestDto input);

        //add new data
        Task CreateAsync(CreateUpdateCategoryDto input);

        //get data by id
        Task<CategoryDto> GetAsync(Guid id);

        //update data by id
        Task UpdateAsync(Guid id, CreateUpdateCategoryDto input);

        //delete data
        Task DeleteAsync(Guid id);
    }
}
