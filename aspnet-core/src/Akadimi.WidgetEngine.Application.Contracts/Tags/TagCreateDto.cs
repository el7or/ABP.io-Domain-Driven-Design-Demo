using System.ComponentModel.DataAnnotations;

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
