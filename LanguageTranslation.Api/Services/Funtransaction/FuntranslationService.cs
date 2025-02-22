using System;
using System.Text.Json;

namespace LanguageTranslation.Api.Services.Funtransaction
{
	public class FuntranslationService: IFuntranslationService
	{
        private readonly HttpClient _httpClient;
		private readonly ILogger<FuntranslationService> _logger;
        public FuntranslationService(ILogger<FuntranslationService> logger,HttpClient httpClient)
		{
			_logger = logger;
			_httpClient = httpClient ?? throw new ArgumentNullException(nameof(HttpClient));
		}

		public async Task<GetTranslatedTextResponseDto> GetTranslatedTextAsync(OriginalTextInfo originalTextInfo)
		{
			var httpResponseMessage = await _httpClient.PostAsJsonAsync($"/translate/{originalTextInfo.Language}.json",new GetTranslatedTextRequestDto
			{
				Text = originalTextInfo.OrignalText
			});
			httpResponseMessage.EnsureSuccessStatusCode();
			var content = await httpResponseMessage.Content.ReadAsStringAsync();
			return JsonSerializer.Deserialize<GetTranslatedTextResponseDto>(content) ;
		}
	}
}

