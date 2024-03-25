using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICategoriesService
    {
        Task<List<CategoryDTO>> GetAllAsync();
        Task<CategoryDTO?> GetByIdAsync(int id);
        Task CreateAsync(CategoryCreateDTO category);
        Task DeleteAsync(int id);
        Task EditAsync(CategoryDTO category);

    }
}
