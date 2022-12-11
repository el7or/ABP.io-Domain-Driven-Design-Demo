using System;
using System.ComponentModel.DataAnnotations;

namespace Akadimi.WidgetEngine.Authors
{
    public class AuthorCreateDto
    {
        [Required]
        [StringLength(AuthorConsts.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public string ShortBio { get; set; }
    }
}
