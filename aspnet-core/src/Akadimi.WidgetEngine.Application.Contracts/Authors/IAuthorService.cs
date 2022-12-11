using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Akadimi.WidgetEngine.Authors
{
    public interface IAuthorService : IApplicationService
    {
        Task<AuthorDto> GetAsync(Guid id);

        Task<PagedResultDto<AuthorDto>> GetListAsync(AuthorGetListDto input);

        Task<AuthorDto> CreateAsync(AuthorCreateDto input);

        Task UpdateAsync(Guid id, AuthorUpdateDto input);

        Task DeleteAsync(Guid id);
    }
}
