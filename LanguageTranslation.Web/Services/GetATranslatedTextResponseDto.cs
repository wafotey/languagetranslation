using System;
using System.Text.Json.Serialization;

namespace LanguageTranslation.Web.Services
{
	public class GetATranslatedTextResponseDto
	{
        [JsonPropertyName("text")]
        public string? Text { get; set; }
        [JsonPropertyName("translated")]
        public string? Translated { get; set; }
    }
}

