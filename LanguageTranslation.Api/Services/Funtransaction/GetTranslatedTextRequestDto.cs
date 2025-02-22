using System;
using System.Text.Json.Serialization;

namespace LanguageTranslation.Api.Services.Funtransaction
{
	public class GetTranslatedTextRequestDto
	{
        [JsonPropertyName("text")]
        public string Text { get; set; } = string.Empty;
    }
}

