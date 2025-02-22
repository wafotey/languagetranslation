using System;
namespace LanguageTranslation.Api.Queries.TranslationEndpoints
{
	public class TranslationTextEndpointGetListRequest
	{
        public Guid? LanguageId { get; set; }

        public TranslationTextEndpointGetListRequest(Guid? languageId)
        {
            LanguageId = languageId;
        }
    }
}

