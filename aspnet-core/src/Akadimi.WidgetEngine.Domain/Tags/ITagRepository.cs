using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Akadimi.WidgetEngine.Tags
{
    public interface ITagRepository : IRepository<Tag, Guid>
    {
        Task<Tag> FindByNameAsync(string name);

        Task<List<Tag>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}