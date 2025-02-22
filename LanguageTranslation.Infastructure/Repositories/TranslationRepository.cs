using System;
using LanguageTranslation.Domain.AggregateRoot.TranslationAggregate;
using Microsoft.EntityFrameworkCore;

namespace LanguageTranslation.Infastructure.Repositories
{
	public class TranslationRepository: ITranslationRepository
    {
        private readonly TranslationContext _context;
		public TranslationRepository(TranslationContext context)
		{
            _context = context ?? throw new ArgumentNullException(nameof(TranslationContext));
		}

        public Translation Add(Translation translation)
        {
            return _context.Set<Translation>().Add(translation).Entity;
        }

        public async Task<List<Translation>> GetAllTranslations()
        {
             return await _context.Set<Translation>().ToListAsync();
        }

        public async Task<Translation> GetTranslationId(Guid Id)
        {
            return await _context.Set<Translation>().FirstOrDefaultAsync(t => t.Id == Id);
        }

        public void Update(Translation translation)
        {
              _context.Set<Translation>().Update(translation);
        }
    }
}

