using Volo.Abp;

namespace Akadimi.WidgetEngine.Authors
{
    public class AuthorAlreadyExistsException : BusinessException
    {
        public AuthorAlreadyExistsException(string name)
            : base(WidgetEngineDomainErrorCodes.AuthorAlreadyExists)
        {
            WithData("name", name);
        }
    }
}
