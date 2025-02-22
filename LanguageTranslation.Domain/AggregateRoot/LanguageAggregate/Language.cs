using LanguageTranslation.Domain.Shared;

namespace LanguageTranslation.Domain.AggregateRoot.LanguageAggregate
{
    public class Language : Entity, IAggregateRoot
    {
        public string? Name { get; set; }

        private Language(){}

        public Language(string name)
        {
            Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentNullException(nameof(name));
        }
       
    }
}

