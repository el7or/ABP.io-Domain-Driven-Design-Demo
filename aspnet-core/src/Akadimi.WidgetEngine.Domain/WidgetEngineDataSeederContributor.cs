using System;
using System.Threading.Tasks;
using Akadimi.WidgetEngine.Books;
using Akadimi.WidgetEngine.Tags;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Akadimi.WidgetEngine
{
    public class WidgetEngineDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Book, Guid> _bookRepository;
        private readonly ITagRepository _tagRepository;
        private readonly TagManager _tagManager;

        public WidgetEngineDataSeederContributor(IRepository<Book, Guid> bookRepository,
            ITagRepository tagRepository,
            TagManager tagManager)
        {
            _bookRepository = bookRepository;
            _tagRepository = tagRepository;
            _tagManager = tagManager;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            // Book Seeds
            if (await _bookRepository.GetCountAsync() <= 0)
            {
                await _bookRepository.InsertAsync(
                    new Book
                    {
                        Name = "1984",
                        Type = BookType.Dystopia,
                        PublishDate = new DateTime(1949, 6, 8),
                        Price = 19.84f
                    },
                    autoSave: true
                );
                await _bookRepository.InsertAsync(
                    new Book
                    {
                        Name = "The Hitchhiker's Guide to the Galaxy",
                        Type = BookType.ScienceFiction,
                        PublishDate = new DateTime(1995, 9, 27),
                        Price = 42.0f
                    },
                    autoSave: true
                );
            }

            // Tags Seeds
            if (await _tagRepository.GetCountAsync() <= 0)
            {
                await _tagRepository.InsertAsync(
                    await _tagManager.CreateAsync(
                        "Adventure",
                        "Adventure books typically involve a journey, and some may include a pursuit. They might also have action-oriented scenes like action films, but the travels and conquests of the main characters primarily define them. This emphasis on a character's adventure can help the audience imagine themselves in those experiences. You can create an adventure film in any setting, as long as your narrative involves a journey."
                    )
                );

                await _tagRepository.InsertAsync(
                    await _tagManager.CreateAsync(
                        "Comedy",
                        "Comedies are books intended to make the audience laugh through their use of exaggeration of language, action or characters who add humor to a situation. Many comedies use everyday situations in their stories to provide a funny commentary on a common life frustration to relate to the audience. Two common comedy formats are comedian-led and situational comedies. There are many subgenres of comedy, including romantic comedy, spoof, parody, satire, sitcom, sketch comedy and mockumentary."
                    )
                );
            }
        }
    }
}
