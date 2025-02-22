using LanguageTranslation.Domain.Shared;

namespace LanguageTranslation.Domain.AggregateRoot.TranslationAggregate
{
    public class Translation : Entity, IAggregateRoot
    {
        public string OriginalText { get; private set; } = string.Empty;
        public string TranslatedText { get; private set; } = string.Empty;
        public Guid LanguageId { get; private set; }

        private Translation() { }

        public Translation(Guid languageId,string translatedText,string originalText)
        {
            OriginalText = !string.IsNullOrWhiteSpace(originalText) ? originalText : throw new ArgumentNullException(nameof(originalText));
            TranslatedText = !string.IsNullOrWhiteSpace(translatedText) ? translatedText : throw new ArgumentNullException(nameof(translatedText));
            LanguageId = languageId;
        }
      
    }
}

