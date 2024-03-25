using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ITagsService
    {
        Task<List<TagDTO>> GetAllAsync();
        Task<TagDTO?> GetByIdAsync(int id);
        Task CreateAsync(TagCreateDTO tag);
        Task DeleteAsync(int id);
        Task EditAsync(TagDTO tag);

    }
}
