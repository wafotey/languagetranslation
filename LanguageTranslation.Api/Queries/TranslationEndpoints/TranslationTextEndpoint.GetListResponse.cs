namespace LanguageTranslation.Api.Queries.TranslationEndpoints
{
	public class TranslationTextEndpointGetListResponse
	{
        public Guid? SelectedLanguage { get; set; }
        public List<TranslationDto> Translations { get; set; } = new List<TranslationDto>();
        public List<LanguageDto> Languages { get; set; } = new List<LanguageDto>();
    }
    
    public class TranslationDto
    {
        public string? Text { get; set; }
        public string? Translated { get; set; }
    }
    public class LanguageDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
}

