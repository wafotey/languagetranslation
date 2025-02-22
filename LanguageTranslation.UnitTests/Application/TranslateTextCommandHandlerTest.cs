using LanguageTranslation.Api.Commands;
using LanguageTranslation.Api.Services.Funtransaction;
using LanguageTranslation.Domain.AggregateRoot.LanguageAggregate;
using LanguageTranslation.Domain.AggregateRoot.TranslationAggregate;
using LanguageTranslation.Infastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace LanguageTranslation.UnitTests.Application
{
	public class TranslateTextCommandHandlerTest
	{
        private readonly Mock<ILanguageRepository> _languageRepository;
        private readonly Mock<ITranslationRepository> _translationRepository;
		private readonly Mock<IFuntranslationService> _funtranslationService;
		private readonly Mock<TranslationContext> _context;
		private readonly Mock<ILogger<TranslateTextCommandHandler>> _logger;

        public TranslateTextCommandHandlerTest()
		{
			_languageRepository = new Mock<ILanguageRepository>();
			_translationRepository = new Mock<ITranslationRepository>();
            _funtranslationService = new Mock<IFuntranslationService>();

			var dbOption = new DbContextOptionsBuilder<TranslationContext>()
						.UseInMemoryDatabase(databaseName: "in-memory")
						.Options;

            _logger =  new Mock<ILogger<TranslateTextCommandHandler>>();
		}

		[Fact]
		public async Task Save_Translation_Success()
		{
			var traslantion = new Translation(Guid.NewGuid(), "Welcome Home", "Home, welocme");

			var language = new Language("Yoga");

			var getTranslatedTextResult = new GetTranslatedTextResponseDto
			{
				Result = new GetTranslatedTextResponseDto.Content
				{
					Text = "me",
					Translated = "we",
					Translation = "nj"
				},
				 ResultInfo = new GetTranslatedTextResponseDto.Success
				 {
					  Total = 1
				 }
			};


            var fakeCommand = new TranslateTextCommand { LanguageId = Guid.NewGuid(), Text = "Welcome Home" };

			 _languageRepository.Setup(languageRepository =>   languageRepository.GetLanguageByIdAsync(fakeCommand.LanguageId)).ReturnsAsync(language);

            _funtranslationService.Setup(funtranslationService => funtranslationService.GetTranslatedTextAsync(It.IsAny<OriginalTextInfo>())).ReturnsAsync(getTranslatedTextResult);

			_translationRepository.Setup(translationRepositry => translationRepositry.Add(traslantion));

            var sut = new TranslateTextCommandHandler(_logger.Object, _funtranslationService.Object, _languageRepository.Object, _translationRepository.Object, _context.Object);

			await sut.Handle(fakeCommand, CancellationToken.None);

            _context.Verify(x => x.SaveChangesAsync(default), Times.Once());
        }

		
	}
}

