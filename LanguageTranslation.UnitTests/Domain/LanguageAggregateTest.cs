using LanguageTranslation.Domain.AggregateRoot.LanguageAggregate;

namespace LanguageTranslation.UnitTests.Domain
{
	public class LanguageAggregateTest
	{
		public LanguageAggregateTest(){}

		[Fact]
		public void Create_Language_Success()
		{
			var name = "aliensLanguge";

			var language = new Language(name);

			Assert.NotNull(language);
		}

		[Fact]
		public void Create_Language_Failed()
		{
			var name = string.Empty;

            Assert.Throws<ArgumentNullException>(() => new Language(name));
        }
	}
}

