using LanguageTranslation.Api.Services.Funtransaction;
using LanguageTranslation.Domain.AggregateRoot.LanguageAggregate;
using LanguageTranslation.Domain.AggregateRoot.TranslationAggregate;
using LanguageTranslation.Infastructure;
using MediatR;

namespace LanguageTranslation.Api.Commands
{
	public class TranslateTextCommandHandler: IRequestHandler<TranslateTextCommand, TranslateTextCommandResponseDto>
	{
        private readonly IFuntranslationService _funtranslationService;
        private readonly ILanguageRepository _languageRepository;
        private readonly ITranslationRepository _translationRepository;
        private readonly ILogger<TranslateTextCommandHandler> _logger;
        private readonly TranslationContext _context;

        public TranslateTextCommandHandler(ILogger<TranslateTextCommandHandler> logger,IFuntranslationService funtranslationService,ILanguageRepository languageRepository,ITranslationRepository translationRepository,TranslationContext context)
		{
            _logger = logger;
            _funtranslationService = funtranslationService ?? throw new ArgumentNullException(nameof(funtranslationService));
            _languageRepository = languageRepository ?? throw new ArgumentNullException(nameof(languageRepository));
            _translationRepository = translationRepository ?? throw new ArgumentNullException(nameof(translationRepository));
            _context = context ?? throw new ArgumentNullException(nameof(TranslationContext));
		}

        public async Task<TranslateTextCommandResponseDto> Handle(TranslateTextCommand request, CancellationToken cancellationToken)
        {
            var language = await _languageRepository.GetLanguageByIdAsync(request.LanguageId);

            var response = await _funtranslationService.GetTranslatedTextAsync(new OriginalTextInfo
            {
                   Language = language?.Name ?? string.Empty,
                   OrignalText = request.Text ?? string.Empty
            });

            _translationRepository.Add(new Translation(language!.Id, response.Result.Translated, response.Result.Text));

            await _context.SaveChangesAsync();


            return new TranslateTextCommandResponseDto
            {
                Text = response.Result.Text,
                Translated = response.Result.Translated
            };
        } 
    }
}

