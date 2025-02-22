using System;
namespace LanguageTranslation.Api.Commands
{
	public class TranslateTextCommandResponseDto
	{
        public string Text { get; set; } = string.Empty;
        public string Translated { get; set; } = string.Empty;
    }
}

