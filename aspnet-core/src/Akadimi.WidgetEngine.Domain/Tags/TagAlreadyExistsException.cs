using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Akadimi.WidgetEngine.Tags
{
    public class TagAlreadyExistsException : BusinessException
    {
        public TagAlreadyExistsException(string name)
            : base(WidgetEngineDomainErrorCodes.TagAlreadyExists)
        {
            WithData("name", name);
        }
    }
}