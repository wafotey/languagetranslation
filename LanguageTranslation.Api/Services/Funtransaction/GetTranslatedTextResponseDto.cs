using System;
using System.Text.Json.Serialization;

namespace LanguageTranslation.Api.Services.Funtransaction
{
	public class GetTranslatedTextResponseDto
	{
        [JsonPropertyName("success")]
        public  Success? ResultInfo { get; set; } 
        [JsonPropertyName("contents")]
        public  Content? Result { get; set; }

        public class Success
        {
            [JsonPropertyName("total")]
            public int Total { get; set; }
        }

        public class Content
        {
            [JsonPropertyName("translation")]
            public string Translation { get; set; } = string.Empty;
            [JsonPropertyName("text")]
            public string Text { get; set; } = string.Empty;
            [JsonPropertyName("translated")]
            public string Translated { get; set; } = string.Empty;
        }
	}
}

