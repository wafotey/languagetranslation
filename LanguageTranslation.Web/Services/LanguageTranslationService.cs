using System.Text.Json;

namespace LanguageTranslation.Web.Services
{
	public class LanguageTranslationService : ILanguageTranslationService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<LanguageTranslationService> _logger;

        public LanguageTranslationService(ILogger<LanguageTranslationService> logger,HttpClient httpClient)
		{
			_logger = logger;
			_httpClient = httpClient ?? throw new ArgumentNullException(nameof(HttpClient));
		}

		public async Task<GetTranslatedTextResponseDto?> GetAllTranslatedText(Guid? languageId)
		{
            var httpResponseMessage = await _httpClient.GetAsync($"translation?languageId={languageId}");
            httpResponseMessage.EnsureSuccessStatusCode();
            var content = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<GetTranslatedTextResponseDto>(content);
        }

        public async Task<GetATranslatedTextResponseDto?> GetTranslatedText(GetATranslatedTextRequestDto request)
        {
            var httpResponseMessage = await _httpClient.PostAsJsonAsync("translation",request);
            httpResponseMessage.EnsureSuccessStatusCode();
            var content = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<GetATranslatedTextResponseDto>(content);
        }
    }
}

