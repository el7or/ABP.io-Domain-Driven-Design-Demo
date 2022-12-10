using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Akadimi.WidgetEngine.Tags
{
    public class TagCreateDto
    {
        [Required]
        [StringLength(TagConsts.MaxNameLength)]
        public string Name { get; set; }

        public string Desc { get; set; }
    }
}
