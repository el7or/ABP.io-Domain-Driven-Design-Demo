using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Akadimi.WidgetEngine.Tags
{
    public class TagService_Tests : WidgetEngineApplicationTestBase
    {
        private readonly ITagService _tagService;

        public TagService_Tests()
        {
            _tagService = GetRequiredService<ITagService>();
        }

        [Fact]
        public async Task Should_Get_All_Tags_Without_Any_Filter()
        {
            var result = await _tagService.GetListAsync(new TagGetListDto());

            result.TotalCount.ShouldBeGreaterThanOrEqualTo(2);
            result.Items.ShouldContain(tag => tag.Name == "Adventure");
            result.Items.ShouldContain(tag => tag.Name == "Comedy");
        }

        [Fact]
        public async Task Should_Get_Filtered_Tags()
        {
            var result = await _tagService.GetListAsync(
                new TagGetListDto { Filter = "Adventure" });

            result.TotalCount.ShouldBeGreaterThanOrEqualTo(1);
            result.Items.ShouldContain(tag => tag.Name == "Adventure");
            result.Items.ShouldNotContain(tag => tag.Name == "Comedy");
        }

        [Fact]
        public async Task Should_Get_Tag_By_Id()
        {
            var tagDto = await _tagService.CreateAsync(
                new TagCreateDto
                {
                    Name = "Action",
                    Desc = "Action films traditionally contain dangerous situations and high-stake risks, and many require the use of physical stunts, fight choreography or disaster sequences. The high-energy elements in these films can aid in achieving audience escapism because viewers often appeal to the story of a hero who struggles against all odds and still achieves victory. The films in this category share a common theme, which is most of their content is action-oriented. They often include having some sense of danger through a majority of their scenes. Some familiar subgenres of the action genre are superhero, disaster and espionage."
                }
            );
            var result = await _tagService.GetAsync(tagDto.Id);

            result.Id.ShouldNotBe(Guid.Empty);
            result.Name.ShouldBe("Action");
        }

        [Fact]
        public async Task Should_Create_A_New_Tag()
        {
            var tagDto = await _tagService.CreateAsync(
                new TagCreateDto
                {
                    Name = "Action",
                    Desc = "Action films traditionally contain dangerous situations and high-stake risks, and many require the use of physical stunts, fight choreography or disaster sequences. The high-energy elements in these films can aid in achieving audience escapism because viewers often appeal to the story of a hero who struggles against all odds and still achieves victory. The films in this category share a common theme, which is most of their content is action-oriented. They often include having some sense of danger through a majority of their scenes. Some familiar subgenres of the action genre are superhero, disaster and espionage."
                }
            );

            tagDto.Id.ShouldNotBe(Guid.Empty);
            tagDto.Name.ShouldBe("Action");
        }

        [Fact]
        public async Task Should_Not_Allow_To_Create_Duplicate_Tag()
        {
            await Assert.ThrowsAsync<TagAlreadyExistsException>(async () =>
            {
                await _tagService.CreateAsync(
                    new TagCreateDto
                    {
                        Name = "Adventure",
                        Desc = "..."
                    }
                );
            });
        }

        [Fact]
        public async Task Should_Update_Exists_Tag()
        {
            var tagDto = await _tagService.CreateAsync(
                new TagCreateDto
                {
                    Name = "Action",
                    Desc = "Action films traditionally contain dangerous situations and high-stake risks, and many require the use of physical stunts, fight choreography or disaster sequences. The high-energy elements in these films can aid in achieving audience escapism because viewers often appeal to the story of a hero who struggles against all odds and still achieves victory. The films in this category share a common theme, which is most of their content is action-oriented. They often include having some sense of danger through a majority of their scenes. Some familiar subgenres of the action genre are superhero, disaster and espionage."
                }
            );
            tagDto.Name = "Drama";
            await _tagService.UpdateAsync(
                tagDto.Id,
                new TagUpdateDto
                {
                    Name = tagDto.Name,
                    Desc = tagDto.Desc
                });
            var result = await _tagService.GetAsync(tagDto.Id);

            result.Name.ShouldBe("Drama");
            result.Name.ShouldNotBe("Action");
        }

        [Fact]
        public async Task Should_Delete_Exists_Tag()
        {
            var tagDto = await _tagService.CreateAsync(
                new TagCreateDto
                {
                    Name = "Action",
                    Desc = "..."
                }
            );
            await _tagService.DeleteAsync(tagDto.Id);
            var result = await _tagService.GetListAsync(
                new TagGetListDto { Filter = "Action" });

            result.TotalCount.ShouldBe(0);
            result.Items.ShouldNotContain(tag => tag.Name == "Action");
        }
    }
}