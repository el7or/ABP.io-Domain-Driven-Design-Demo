using Akadimi.WidgetEngine.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace Akadimi.WidgetEngine.Tags
{
    [Authorize(WidgetEnginePermissions.Tags.Default)]
    public class TagService : WidgetEngineAppService, ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly TagManager _tagManager;

        public TagService(
            ITagRepository tagRepository,
            TagManager tagManager)
        {
            _tagRepository = tagRepository;
            _tagManager = tagManager;
        }

        public async Task<TagDto> GetAsync(Guid id)
        {
            var tag = await _tagRepository.GetAsync(id);
            return ObjectMapper.Map<Tag, TagDto>(tag);
        }

        public async Task<PagedResultDto<TagDto>> GetListAsync(TagGetListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Tag.Name);
            }

            var tags = await _tagRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            var totalCount = input.Filter == null
                ? await _tagRepository.CountAsync()
                : await _tagRepository.CountAsync(
                    tag => tag.Name.Contains(input.Filter));

            return new PagedResultDto<TagDto>(
                totalCount,
                ObjectMapper.Map<List<Tag>, List<TagDto>>(tags)
            );
        }

        [Authorize(WidgetEnginePermissions.Tags.Create)]
        public async Task<TagDto> CreateAsync(TagCreateDto input)
        {
            var tag = await _tagManager.CreateAsync(
                input.Name,
                input.Desc
            );

            await _tagRepository.InsertAsync(tag);

            return ObjectMapper.Map<Tag, TagDto>(tag);
        }

        [Authorize(WidgetEnginePermissions.Tags.Edit)]
        public async Task UpdateAsync(Guid id, TagUpdateDto input)
        {
            var tag = await _tagRepository.GetAsync(id);

            if (tag.Name != input.Name)
            {
                await _tagManager.ChangeNameAsync(tag, input.Name);
            }

            tag.Desc = input.Desc;

            await _tagRepository.UpdateAsync(tag);
        }

        [Authorize(WidgetEnginePermissions.Tags.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _tagRepository.DeleteAsync(id);
        }

    }
}