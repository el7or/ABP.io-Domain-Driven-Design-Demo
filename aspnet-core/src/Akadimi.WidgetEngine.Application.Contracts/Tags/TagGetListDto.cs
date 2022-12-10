using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Akadimi.WidgetEngine.Tags
{
    public class TagGetListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}