using System;
using LanguageTranslation.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace LanguageTranslation.Infastructure
{
	public class TranslationContext: DbContext
    {
		public TranslationContext(DbContextOptions<TranslationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }


        public sealed override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetDatetime();
            return SaveChangesAsync(acceptAllChangesOnSuccess: true, cancellationToken);
        }
        private void SetDatetime()
        {
            var entries = ChangeTracker
                            .Entries()
                            .Where(e => e.Entity is Entity && (
                    e.State == EntityState.Added
                    || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((Entity)entityEntry.Entity).UpdatedAt = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((Entity)entityEntry.Entity).CreatedAt = DateTime.Now;
                }
            }
        }

    }
}

