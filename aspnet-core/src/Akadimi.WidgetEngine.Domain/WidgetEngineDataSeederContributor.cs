using System;
using System.Threading.Tasks;
using Akadimi.WidgetEngine.Authors;
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
        private readonly IAuthorRepository _authorRepository;
        private readonly AuthorManager _authorManager;
        private readonly ITagRepository _tagRepository;
        private readonly TagManager _tagManager;

        public WidgetEngineDataSeederContributor(IRepository<Book, Guid> bookRepository,
            IAuthorRepository authorRepository,
            AuthorManager authorManager,
            ITagRepository tagRepository,
            TagManager tagManager)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _authorManager = authorManager;
            _tagRepository = tagRepository;
            _tagManager = tagManager;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _bookRepository.GetCountAsync() > 0)
            {
                return;
            }

            //Authors Seeds
            var orwell = await _authorRepository.InsertAsync(
                await _authorManager.CreateAsync(
                    "George Orwell",
                    new DateTime(1903, 06, 25),
                    "Orwell produced literary criticism and poetry, fiction and polemical journalism; and is best known for the allegorical novella Animal Farm (1945) and the dystopian novel Nineteen Eighty-Four (1949)."
                )
            );

            var douglas = await _authorRepository.InsertAsync(
                await _authorManager.CreateAsync(
                    "Douglas Adams",
                    new DateTime(1952, 03, 11),
                    "Douglas Adams was an English author, screenwriter, essayist, humorist, satirist and dramatist. Adams was an advocate for environmentalism and conservation, a lover of fast cars, technological innovation and the Apple Macintosh, and a self-proclaimed 'radical atheist'."
                )
            );

            // Books Seeds
            await _bookRepository.InsertAsync(
                new Book
                {
                    AuthorId = orwell.Id, // SET THE AUTHOR
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
                    AuthorId = douglas.Id, // SET THE AUTHOR
                    Name = "The Hitchhiker's Guide to the Galaxy",
                    Type = BookType.ScienceFiction,
                    PublishDate = new DateTime(1995, 9, 27),
                    Price = 42.0f
                },
                autoSave: true
            );

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
