using System;
using LanguageTranslation.Domain.Shared;

namespace LanguageTranslation.Domain.AggregateRoot.LanguageAggregate
{
	public interface ILanguageRepository
	{
        Language Add(Language language);
        void Update(Language language);
        Task<Language?> GetLanguageByIdAsync(Guid Id);
        Task<List<Language>> GetAllLanguagesAsync();
    }
}

