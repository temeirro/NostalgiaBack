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
    public class TagsService : ITagsService
    {
        private readonly IRepository<Tag> _repoTag;
        private readonly IMapper _mapper;
        public TagsService(IRepository<Tag> repoTag, IMapper mapper)
        {
            _repoTag = repoTag;
            _mapper = mapper;
        }
        public async Task CreateAsync(TagCreateDTO tag)
        {
            await _repoTag.InsertAsync(_mapper.Map<Tag>(tag));
            await _repoTag.SaveAsync();
        }

        public async Task<List<TagDTO>> GetAllAsync()
        {
            var tags = await _repoTag.GetAsync();
            return _mapper.Map<List<TagDTO>>(tags);
        }
        public async Task<TagDTO?> GetByIdAsync(int id)
        {
            if (await _repoTag.GetByIDAsync(id) == null)
                return null;
            return _mapper.Map<TagDTO>(await _repoTag.GetByIDAsync(id));
        }
        public async Task DeleteAsync(int id)
        {
            if (await _repoTag.GetByIDAsync(id) == null)
                return;
            await _repoTag.DeleteAsync(id);
            await _repoTag.SaveAsync();
        }
        public async Task EditAsync(TagDTO tag)
        {
            await _repoTag.UpdateAsync(_mapper.Map<Tag>(tag));
            await _repoTag.SaveAsync();
        }
    }
}
