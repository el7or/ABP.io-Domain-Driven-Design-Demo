using System;
using System.Threading.Tasks;
using Akadimi.WidgetEngine.Authors;
using Akadimi.WidgetEngine.Tags;
using Shouldly;
using Xunit;

namespace Akadimi.WidgetEngine.Authors
{
    public class AuthorService_Tests : WidgetEngineApplicationTestBase
    {
        private readonly IAuthorService _authorService;

        public AuthorService_Tests()
        {
            _authorService = GetRequiredService<IAuthorService>();
        }

        [Fact]
        public async Task Should_Get_All_Authors_Without_Any_Filter()
        {
            var result = await _authorService.GetListAsync(new AuthorGetListDto());

            result.TotalCount.ShouldBeGreaterThanOrEqualTo(2);
            result.Items.ShouldContain(author => author.Name == "George Orwell");
            result.Items.ShouldContain(author => author.Name == "Douglas Adams");
        }

        [Fact]
        public async Task Should_Get_Filtered_Authors()
        {
            var result = await _authorService.GetListAsync(
                new AuthorGetListDto { Filter = "George" });

            result.TotalCount.ShouldBeGreaterThanOrEqualTo(1);
            result.Items.ShouldContain(author => author.Name == "George Orwell");
            result.Items.ShouldNotContain(author => author.Name == "Douglas Adams");
        }

        [Fact]
        public async Task Should_Get_Author_By_Id()
        {
            var authorDto = await _authorService.CreateAsync(
                new AuthorCreateDto
                {
                    Name = "Edward Bellamy",
                    BirthDate = new DateTime(1850, 05, 22),
                    ShortBio = "Edward Bellamy was an American author..."
                }
            );
            var result = await _authorService.GetAsync(authorDto.Id);

            result.Id.ShouldNotBe(Guid.Empty);
            result.Name.ShouldBe("Edward Bellamy");
        }

        [Fact]
        public async Task Should_Create_A_New_Author()
        {
            var authorDto = await _authorService.CreateAsync(
                new AuthorCreateDto
                {
                    Name = "Edward Bellamy",
                    BirthDate = new DateTime(1850, 05, 22),
                    ShortBio = "Edward Bellamy was an American author..."
                }
            );

            authorDto.Id.ShouldNotBe(Guid.Empty);
            authorDto.Name.ShouldBe("Edward Bellamy");
        }

        [Fact]
        public async Task Should_Not_Allow_To_Create_Duplicate_Author()
        {
            await Assert.ThrowsAsync<AuthorAlreadyExistsException>(async () =>
            {
                await _authorService.CreateAsync(
                    new AuthorCreateDto
                    {
                        Name = "Douglas Adams",
                        BirthDate = DateTime.Now,
                        ShortBio = "..."
                    }
                );
            });
        }

        [Fact]
        public async Task Should_Update_Exists_Author()
        {
            var authorDto = await _authorService.CreateAsync(
                new AuthorCreateDto
                {
                    Name = "Edward Bellamy",
                    BirthDate = new DateTime(1850, 05, 22),
                    ShortBio = "Edward Bellamy was an American author..."
                }
            );
            authorDto.Name = "Bellamy";
            await _authorService.UpdateAsync(
                authorDto.Id,
                new AuthorUpdateDto
                {
                    Name = authorDto.Name,
                    BirthDate = authorDto.BirthDate,
                    ShortBio = authorDto.ShortBio
                });
            var result = await _authorService.GetAsync(authorDto.Id);

            result.Name.ShouldBe("Bellamy");
            result.Name.ShouldNotBe("Edward Bellamy");
        }

        [Fact]
        public async Task Should_Delete_Exists_Author()
        {
            var tagDto = await _authorService.CreateAsync(
                new AuthorCreateDto
                {
                    Name = "Edward Bellamy",
                    BirthDate = new DateTime(1850, 05, 22),
                    ShortBio = "Edward Bellamy was an American author..."
                }
            );
            await _authorService.DeleteAsync(tagDto.Id);
            var result = await _authorService.GetListAsync(
                new AuthorGetListDto { Filter = "Bellamy" });

            result.TotalCount.ShouldBe(0);
            result.Items.ShouldNotContain(tag => tag.Name == "Bellamy");
        }
    }
}
