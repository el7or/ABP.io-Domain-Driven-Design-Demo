using Akadimi.WidgetEngine.Books;
using AutoMapper;

namespace Akadimi.WidgetEngine;

public class WidgetEngineApplicationAutoMapperProfile : Profile
{
    public WidgetEngineApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Book, BookDto>()
            .ForMember(res => res.Type, opt => opt.MapFrom(c => c.Type.ToString()));
        CreateMap<CreateUpdateBookDto, Book>();
    }
}
