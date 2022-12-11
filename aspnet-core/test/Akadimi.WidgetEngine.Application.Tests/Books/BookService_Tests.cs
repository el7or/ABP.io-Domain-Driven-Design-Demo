using System;
using System.Linq;
using System.Threading.Tasks;
using Akadimi.WidgetEngine.Authors;
using Shouldly;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Validation;
using Xunit;

namespace Akadimi.WidgetEngine.Books
{
    public class BookService_Tests : WidgetEngineApplicationTestBase
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;

        public BookService_Tests()
        {
            _bookService = GetRequiredService<IBookService>();
            _authorService = GetRequiredService<IAuthorService>();
        }

        [Fact]
        public async Task Should_Get_List_Of_Books()
        {
            //Act
            var result = await _bookService.GetListAsync(
                new PagedAndSortedResultRequestDto()
            );

            //Assert
            result.TotalCount.ShouldBeGreaterThan(0);
            result.Items.ShouldContain(b => b.Name == "1984" &&
                                       b.AuthorName == "George Orwell");
        }

        [Fact]
        public async Task Should_Create_A_Valid_Book()
        {
            var authors = await _authorService.GetListAsync(new AuthorGetListDto());
            var firstAuthor = authors.Items.First();

            //Act
            var result = await _bookService.CreateAsync(
                new BookCreateUpdateDto
                {
                    AuthorId = firstAuthor.Id,
                    Name = "New test book 42",
                    Price = 10,
                    PublishDate = DateTime.Now,
                    Type = BookType.ScienceFiction
                }
            );

            //Assert
            result.Id.ShouldNotBe(Guid.Empty);
            result.Name.ShouldBe("New test book 42");
        }

        [Fact]
        public async Task Should_Not_Create_A_Book_Without_Name()
        {
            var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
            {
                await _bookService.CreateAsync(
                    new BookCreateUpdateDto
                    {
                        Name = "",
                        Price = 10,
                        PublishDate = DateTime.Now,
                        Type = BookType.ScienceFiction
                    }
                );
            });

            exception.ValidationErrors
                .ShouldContain(err => err.MemberNames.Any(m => m == "Name"));
        }
    }
}
