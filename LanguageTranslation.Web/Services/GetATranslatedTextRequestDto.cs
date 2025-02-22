using System;
namespace LanguageTranslation.Web.Services
{
	public class GetATranslatedTextRequestDto
	{
		public Guid LanguageId { get; set; }
		public string? Text { get; set; }
	}
}

