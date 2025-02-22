using System;
using LanguageTranslation.Domain.AggregateRoot.LanguageAggregate;
using LanguageTranslation.Domain.AggregateRoot.TranslationAggregate;
using LanguageTranslation.Infastructure.Repositories;

namespace LanguageTranslation.Api.Extensions
{
	public  static class RepositoriesExtensions
	{
		public static void AddRepositories(this IServiceCollection services)
		{
			services.AddScoped<ITranslationRepository, TranslationRepository>();
			services.AddScoped<ILanguageRepository, LanguageRepository>();
        }
	}
}

