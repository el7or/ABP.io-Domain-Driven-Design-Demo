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