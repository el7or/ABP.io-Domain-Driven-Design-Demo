using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Akadimi.WidgetEngine.Tags
{
    public interface ITagService : IApplicationService
    {
        Task<TagDto> GetAsync(Guid id);

        Task<PagedResultDto<TagDto>> GetListAsync(TagGetListDto input);

        Task<TagDto> CreateAsync(TagCreateDto input);

        Task UpdateAsync(Guid id, TagUpdateDto input);

        Task DeleteAsync(Guid id);
    }
}