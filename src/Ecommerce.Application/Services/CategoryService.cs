using Ecommerce.Interface;
using Ecommerce.ModelDtos;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace Ecommerce.Services
{
    public class CategoryService : EcommerceAppService, ICategoryAppService
    {
        private readonly IRepository<Category, Guid> _categoryRepository;

        public CategoryService(IRepository<Category, Guid> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task CreateAsync(CreateUpdateCategoryDto input)
        {
            await _categoryRepository.InsertAsync(ObjectMapper.Map<CreateUpdateCategoryDto, Category>(input));
        }

        public async Task DeleteAsync(Guid id)
        {
            await _categoryRepository.DeleteAsync(id);
        }

        public async Task<CategoryDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Category, CategoryDto>(
                await _categoryRepository.GetAsync(id));
        }

        public async Task<PagedResultDto<CategoryDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var queryable = await _categoryRepository.WithDetailsAsync();
            queryable = queryable.Skip(input.SkipCount)
                .Take(input.MaxResultCount)
                .OrderBy(input.Sorting ?? nameof(Category.Name));

            var count = await _categoryRepository.GetCountAsync();

            var categories = await AsyncExecuter.ToListAsync(queryable);
            return new PagedResultDto<CategoryDto>(
                count,
                ObjectMapper.Map<List<Category>, List<CategoryDto>>(categories)
                );
        }

        public async Task UpdateAsync(Guid id, CreateUpdateCategoryDto input)
        {
            var category = await _categoryRepository.GetAsync(id);
            ObjectMapper.Map(input, category);
        }
    }
}
