using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Core.Services
{
    public class PostImagesService : IPostImageService
    {
        private readonly IRepository<PostImage> _imageRepository;
        private readonly IFilesService _filesService;
        private readonly IMapper _mapper;
        public PostImagesService(IRepository<PostImage> imageRepository, IFilesService filesService, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _filesService = filesService;
            _mapper = mapper;
        }
        public async Task<PostImage> CreateImageAsync(IFormFile ImageFile)
        {
            PostImage image = new PostImage()
            {
                ImagePath = await _filesService.SavePostImage(ImageFile)
            };
            await _imageRepository.InsertAsync(image);
            await _imageRepository.SaveAsync();
            return image;
        }

        public async Task EditAsync(PostImageDTO imageDTO)
        {
            var image = _mapper.Map<PostImage>(imageDTO);
            await _imageRepository.UpdateAsync(image);
            await _imageRepository.SaveAsync();
        }
        public async Task<PostImageDTO?> GetByIdAsync(int id)
        {
            if (await _imageRepository.GetByIDAsync(id) == null)
                return null;
            return _mapper.Map<PostImageDTO>(await _imageRepository.GetByIDAsync(id));
        }
        public async Task DeleteImageAsync(PostImageDTO imageDTO)
        {
            await _filesService.DeletePostImage(imageDTO.ImagePath!);
            await DeleteByIdAsync(imageDTO.Id);
        }
        public async Task DeleteByIdAsync(int id)
        {
            var image = await _imageRepository.GetByIDAsync(id);
            if (image != null)
            {
                await _imageRepository.DeleteAsync(image);
                await _imageRepository.SaveAsync();
            }
        }
        public async Task<List<PostImageDTO>>? GetImagesByPostIDAsync(int id)
        {
            var image = await _imageRepository.GetByIDAsync(id);
            return _mapper.Map<List<PostImageDTO>>(image);
        }
    }
}
