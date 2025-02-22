using System;
using LanguageTranslation.Domain.AggregateRoot.LanguageAggregate;
using LanguageTranslation.Infastructure.SeedData;
using Microsoft.EntityFrameworkCore;

namespace LanguageTranslation.Infastructure.Extensions
{
	public static class SeedDataExtensions
	{
		public static void SeedData(this TranslationContext context)
		{
            context.Database.Migrate();
            if (!context.Set<Language>().Any())
            {
                var bankCodeSeedData = LanguageData.GetLanguages();
                context.AddRange(bankCodeSeedData);
                context.SaveChanges();
            }
        }
	}
}

