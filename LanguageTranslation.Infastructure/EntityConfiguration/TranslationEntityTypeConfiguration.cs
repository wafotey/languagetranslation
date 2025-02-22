using LanguageTranslation.Domain.AggregateRoot.TranslationAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LanguageTranslation.Infastructure.EntityConfiguration
{
	public class TranslationEntityTypeConfiguration: IEntityTypeConfiguration<Translation>
    {

        public void Configure(EntityTypeBuilder<Translation> builder)
        {
            builder
            .Property(b => b.Id)
            .IsRequired();
        }
    }
}

