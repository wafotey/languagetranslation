using LanguageTranslation.Domain.AggregateRoot.TranslationAggregate;

namespace LanguageTranslation.UnitTests.Domain
{
	public class TranslationAggregateTest
	{
        [Fact]
        public void Create_Translation_Success()
        {
            var orginalText = "Welcome home";
            var translatedText = "Wecelem ome";
            var langugeId = Guid.NewGuid();

            var translated = new Translation(langugeId, translatedText, orginalText);

            Assert.NotNull(translated);
        }

        [Fact]
        public void Create_Translation_Failed()
        {
            var orginalText = string.Empty;
            var translatedText = string.Empty;
            var langugeId = Guid.NewGuid();

            Assert.Throws<ArgumentNullException>(() => new Translation(langugeId, translatedText, orginalText));
        }
    }

	
}

