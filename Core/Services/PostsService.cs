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
    public class PostsService : IPostsService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Post> _postRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Tag> _tagRepository;
        private readonly IRepository<PostImage> _postImageRepository;
        private readonly IFilesService _filesService;
        private readonly IPostImageService _postImagesService;
        public PostsService(IMapper mapper, IRepository<Post> postRepository, IRepository<Tag> tagRepository, IRepository<Category> categoryRepository, IRepository<PostImage> postImageRepository, IFilesService filesService, IPostImageService postImagesService)
        {
            _mapper = mapper;

            _postRepository = postRepository;
            _tagRepository = tagRepository;
            _categoryRepository = categoryRepository;
            _postImageRepository = postImageRepository;

            _filesService = filesService;
            _postImagesService = postImagesService;
        }
        public async Task CreateAsync(PostCreateDTO postDTO)
        {
            var post = _mapper.Map<Post>(postDTO);
            post.PostedOn = DateTime.Now;
            post.Modified = DateTime.Now;

            // Get the category
            var category = await _categoryRepository.GetByIDAsync(postDTO.CategoryId);
            if (category == null)
            {
                throw new Exception("Invalid category ID.");
            }
            post.Category = category;

            await _postRepository.InsertAsync(post);
            await _postRepository.SaveAsync();

            // Handle tags
            if (postDTO.TagIds != null && postDTO.TagIds.Any())
            {
                var tags = await _tagRepository.GetAsync(); // Retrieve all available tags
                var selectedTags = tags.Where(t => postDTO.TagIds.Contains(t.Id)).ToList(); // Select only the tags that are associated with the post
                foreach (var tag in selectedTags)
                {
                    post.Tags.Add(new PostTag { TagId = tag.Id, PostId = post.Id });
                }
                await _postRepository.SaveAsync(); // Save changes
            }

            // Handle post images
            if (postDTO.PostImages != null)
            {
                foreach (var imageFile in postDTO.PostImages)
                {
                    var imageResult = await _postImageRepository.GetByIDAsync(imageFile.Id);
                    var image = _mapper.Map<PostImageDTO>(imageResult);
                    image.PostId = post.Id;
                    image.ImagePath = imageFile.ImagePath;
                    await _postImagesService.EditAsync(image);
                }
            }
        }
        public async Task<PostDTO?> GetByIdAsync(int id)
        {
            if (await _postRepository.GetByIDAsync(id) == null)
                return null;
            return _mapper.Map<PostDTO>(await _postRepository.GetByIDAsync(id));
        }
        public async Task<List<PostDTO>> GetAllAsync()
        {
            var posts = await _postRepository.GetAsync();
            return _mapper.Map<List<PostDTO>>(posts);
        }

        public async Task DeletePostByIDAsync(int id)
        {
            var post = await _postRepository.GetByIDAsync(id);
            var imageClass = await _postImagesService.GetImagesByPostIDAsync(id)!;
            if (imageClass != null)
            {
                foreach (var image in imageClass)
                {
                    await _filesService.DeletePostImage(image.ImagePath!);
                }
                foreach (var image in imageClass)
                {
                    await _postImageRepository.DeleteAsync(image.Id);
                    await _postImageRepository.SaveAsync();
                }
            }
          
            var postToDelete = await _postRepository.GetByIDAsync(id);
            if (postToDelete != null)
            {
                await _postRepository.DeleteAsync(postToDelete);
                await _postRepository.SaveAsync();
            }
        }
    }
}
