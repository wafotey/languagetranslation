using LanguageTranslation.Web.ViewModel;

namespace LanguageTranslation.Web.Services
{
	public interface ILanguageTranslationService
	{
        Task<GetTranslatedTextResponseDto?> GetAllTranslatedText(Guid? languageId);
        Task<GetATranslatedTextResponseDto?> GetTranslatedText(GetATranslatedTextRequestDto request);
    }
}

