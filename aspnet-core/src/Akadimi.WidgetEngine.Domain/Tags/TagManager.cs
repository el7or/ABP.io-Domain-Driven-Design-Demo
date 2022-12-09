using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using Volo.Abp.Guids;
using Volo.Abp;

namespace Akadimi.WidgetEngine.Tags
{
    public class TagManager : DomainService
    {
        private readonly ITagRepository _authorRepository;

        public TagManager(ITagRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Tag> CreateAsync(
            [NotNull] string name,
            [CanBeNull] string desc = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var existingTag = await _authorRepository.FindByNameAsync(name);
            if (existingTag != null)
            {
                throw new TagAlreadyExistsException(name);
            }

            return new Tag(
                GuidGenerator.Create(),
                name,
                desc
            );
        }

        public async Task ChangeNameAsync(
            [NotNull] Tag author,
            [NotNull] string newName)
        {
            Check.NotNull(author, nameof(author));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));

            var existingTag = await _authorRepository.FindByNameAsync(newName);
            if (existingTag != null && existingTag.Id != author.Id)
            {
                throw new TagAlreadyExistsException(newName);
            }

            author.ChangeName(newName);
        }
    }
}