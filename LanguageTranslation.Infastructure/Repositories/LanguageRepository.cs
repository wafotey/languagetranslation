using System;
using LanguageTranslation.Domain.AggregateRoot.LanguageAggregate;
using Microsoft.EntityFrameworkCore;

namespace LanguageTranslation.Infastructure.Repositories
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly TranslationContext _context;
        public LanguageRepository(TranslationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(TranslationContext));
        }
        public Language Add(Language language)
        {
            return _context.Set<Language>().Add(language).Entity;
        }

        public async Task<List<Language>> GetAllLanguagesAsync()
        {
            return await _context.Set<Language>().ToListAsync();
        }

        public async Task<Language?> GetLanguageByIdAsync(Guid Id)
        {
            return await _context.Set<Language>().FirstOrDefaultAsync(l => l.Id == Id);
        }

        public void Update(Language language)
        {
            _context.Set<Language>().Update(language);
        }
    }
}

