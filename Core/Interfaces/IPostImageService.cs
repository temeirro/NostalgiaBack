using Core.DTOs;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPostImageService
    {
        Task<PostImage> CreateImageAsync(IFormFile ImageFile);
        Task EditAsync(PostImageDTO imageDTO);

    }
}
