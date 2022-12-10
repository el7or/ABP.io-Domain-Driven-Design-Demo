using Akadimi.WidgetEngine.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Akadimi.WidgetEngine.Books
{
    public class BookService :
        CrudAppService<
            Book, //The Book entity
            BookDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            BookDtoCreateUpdate>, //Used to create/update a book
        IBookService //implement the IBookService
    {
        public BookService(IRepository<Book, Guid> repository)
            : base(repository)
        {
            GetPolicyName = WidgetEnginePermissions.Books.Default;
            GetListPolicyName = WidgetEnginePermissions.Books.Default;
            CreatePolicyName = WidgetEnginePermissions.Books.Create;
            UpdatePolicyName = WidgetEnginePermissions.Books.Edit;
            DeletePolicyName = WidgetEnginePermissions.Books.Delete;
        }
    }
}