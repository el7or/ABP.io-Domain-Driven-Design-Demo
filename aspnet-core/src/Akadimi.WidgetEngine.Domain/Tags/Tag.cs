using JetBrains.Annotations;
using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp;

namespace Akadimi.WidgetEngine.Tags
{
    public class Tag : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; private set; }
        public string Desc { get; set; }

        private Tag()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        internal Tag(
            Guid id,
            [NotNull] string name,
            [CanBeNull] string desc = null)
            : base(id)
        {
            SetName(name);
            Desc = desc;
        }

        internal Tag ChangeName([NotNull] string name)
        {
            SetName(name);
            return this;
        }

        private void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(
                name,
                nameof(name),
                maxLength: TagConsts.MaxNameLength
            );
        }
    }
}