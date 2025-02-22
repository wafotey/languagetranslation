using System;
using System.Text.Json.Serialization;

namespace LanguageTranslation.Web.Services
{
	public class GetTranslatedTextResponseDto
	{
        [JsonPropertyName("selectedLanguage")]
        public Guid? SelectedLanguage { get; set; }
        [JsonPropertyName("translations")]
        public List<TranslationDto> Translations { get; set; } = new List<TranslationDto>();
        [JsonPropertyName("languages")]
        public List<LanguageDto> Languages { get; set; } = new List<LanguageDto>();
    }

    public class TranslationDto
    {
        [JsonPropertyName("text")]
        public string? Text { get; set; }
        [JsonPropertyName("translated")]
        public string? Translated { get; set; }
    }

    public class LanguageDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}

