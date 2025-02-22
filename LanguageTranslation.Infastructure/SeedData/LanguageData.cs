using LanguageTranslation.Domain.AggregateRoot.LanguageAggregate;

namespace LanguageTranslation.Infastructure.SeedData
{
    public class LanguageData
    {
        public static List<Language> GetLanguages()
        {
            return new List<Language>
            {
                new Language("Shakespeare"),
                new Language("Oldenglish"),
                new Language("Brooklyn"),
                new Language("Australian"),
                new Language("Pig-latin"),
                new Language("Irish"),
                new Language("Yoda"),
                new Language("Pirate"),
                new Language("Sith"),
                new Language("Gungan"),
                new Language("Huttese"),
                new Language("Mandalorian"),
                new Language("Valyrian"),
                new Language("Dothraki"),
                new Language("Chef"),
                new Language("Numbers"),
                new Language("Emoji"),
                new Language("Wheel-of-time-old-tongue"),
                new Language("Asian-accent"),
                new Language("German-accent"),
            };
        }
    }
}

