using LanguageTranslation.Domain.AggregateRoot.LanguageAggregate;
using LanguageTranslation.Domain.AggregateRoot.TranslationAggregate;
using LanguageTranslation.Infastructure;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Endpoint;

namespace LanguageTranslation.Api.Queries.TranslationEndpoints
{
	public class TranslationTextEndpoint: IEndpoint<IResult, TranslationTextEndpointGetListRequest, ILanguageRepository,TranslationContext>
    {
        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapGet("translation",
            async (Guid languageId, ILanguageRepository languageRepository, TranslationContext context) =>
            {
                return await HandleAsync(new TranslationTextEndpointGetListRequest(languageId),languageRepository, context);
            })
           .Produces<TranslationTextEndpointGetListResponse>()
           .WithTags("Translations");
        }

        public async Task<IResult> HandleAsync(TranslationTextEndpointGetListRequest request, ILanguageRepository languageRepository,TranslationContext context)
        {
            Language? language;
            var response = new TranslationTextEndpointGetListResponse();

            if (request.LanguageId == Guid.Empty)
            {
                language = await context.Set<Language>().FirstOrDefaultAsync();
                if (language is null)
                    return Results.Ok(response);
            }
            else
                language = await context.Set<Language>().FirstOrDefaultAsync(l => l.Id == request.LanguageId);

            var languages =  await context.Set<Language>().FromSqlRaw("EXECUTE GetAllLanguagesStoreProcedure").ToListAsync();

            var translations = await context.Set<Translation>().FromSqlRaw("EXECUTE GetAllTranslationByLanguageStoreProcedure @languageId={0}",language?.Id ?? default).ToListAsync();

           

            response.SelectedLanguage = language?.Id;

            foreach(Language alanguage in languages)
            {
                response.Languages.Add(new LanguageDto
                {
                     Id = alanguage.Id,
                     Name = alanguage.Name
                });
            }

            foreach(Translation translation in translations)
            {
                response.Translations.Add(new TranslationDto
                {
                    Text = translation.OriginalText,
                    Translated = translation.TranslatedText
                });
            }

            return Results.Ok(response);
        }
    }
}

