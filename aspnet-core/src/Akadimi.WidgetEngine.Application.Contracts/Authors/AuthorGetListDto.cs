using Volo.Abp.Application.Dtos;

namespace Akadimi.WidgetEngine.Authors
{
    public class AuthorGetListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}