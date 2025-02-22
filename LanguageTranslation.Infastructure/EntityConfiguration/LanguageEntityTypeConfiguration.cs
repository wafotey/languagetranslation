using System;
using LanguageTranslation.Domain.AggregateRoot.LanguageAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LanguageTranslation.Infastructure.EntityConfiguration
{
	public class LanguageEntityTypeConfiguration: IEntityTypeConfiguration<Language>
    {

        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder
             .Property(b => b.Id)
             .IsRequired();

        }
    }
}

