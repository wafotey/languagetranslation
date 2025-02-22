using System;
using LanguageTranslation.Domain.Shared;

namespace LanguageTranslation.Domain.AggregateRoot.TranslationAggregate
{
	public interface ITranslationRepository
	{
        Translation Add(Translation translation);
        void Update(Translation translation);
        Task<Translation> GetTranslationId(Guid Id);
        Task<List<Translation>> GetAllTranslations();
    }
}

