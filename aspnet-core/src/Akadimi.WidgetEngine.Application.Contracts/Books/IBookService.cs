﻿using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Akadimi.WidgetEngine.Books
{
    public interface IBookService :
        ICrudAppService< //Defines CRUD methods
            BookDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            BookDtoCreateUpdate> //Used to create/update a book
    {

    }
}
