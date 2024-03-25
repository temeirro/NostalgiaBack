using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPostsService
    {
        Task<List<PostDTO>> GetAllAsync();
        Task CreateAsync(PostCreateDTO postDTO);
        Task DeletePostByIDAsync(int id);
        Task<PostDTO?> GetByIdAsync(int id);


    }
}
