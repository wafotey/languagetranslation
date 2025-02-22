using System;
namespace LanguageTranslation.Api.Services.Funtransaction
{
	public interface IFuntranslationService
	{
        Task<GetTranslatedTextResponseDto> GetTranslatedTextAsync(OriginalTextInfo originalTextInfo);
    }
}

