using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IRepository<Category> _repoCategory;
        private readonly IMapper _mapper;

        public CategoriesService(IRepository<Category> repoCategory, IMapper mapper)
        {
            _repoCategory = repoCategory;
            _mapper = mapper;
        }

        public async Task<List<CategoryDTO>> GetAllAsync()
        {
            var categories = await _repoCategory.GetAsync();
            return _mapper.Map<List<CategoryDTO>>(categories);
        }
        public async Task<CategoryDTO?> GetByIdAsync(int id)
        {
            if (await _repoCategory.GetByIDAsync(id) == null)
                return null;
            return _mapper.Map<CategoryDTO>(await _repoCategory.GetByIDAsync(id));
        }
        public async Task CreateAsync(CategoryCreateDTO category)
        {
            await _repoCategory.InsertAsync(_mapper.Map<Category>(category));
            await _repoCategory.SaveAsync();
        }
        public async Task DeleteAsync(int id)
        {
            if (await _repoCategory.GetByIDAsync(id) == null)
                return;
            await _repoCategory.DeleteAsync(id);
            await _repoCategory.SaveAsync();
        }
        public async Task EditAsync(CategoryDTO category)
        {
            await _repoCategory.UpdateAsync(_mapper.Map<Category>(category));
            await _repoCategory.SaveAsync();
        }
    }

}
