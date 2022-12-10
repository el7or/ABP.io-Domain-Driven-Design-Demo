using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Akadimi.WidgetEngine.Tags
{
    public class TagDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public string Desc { get; set; }
    }
}