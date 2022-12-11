using System;
using Volo.Abp.Application.Dtos;

namespace Akadimi.WidgetEngine.Books
{
    public class AuthorLookupDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
