using System;
using LanguageTranslation.Infastructure;
using Microsoft.EntityFrameworkCore;

namespace LanguageTranslation.Api.Factories
{
	public class DesignTimeDbContextFactory
	{
        public TranslationContext CreateDbContext(string[] args)
        {
            string path = Directory.GetCurrentDirectory();

            IConfigurationBuilder builder =
                new ConfigurationBuilder()
                    .SetBasePath(path)
                    .AddJsonFile("appsettings.json");

            IConfigurationRoot config = builder.Build();

            string connectionString = config.GetConnectionString(nameof(TranslationContext)) ?? string.Empty;

            Console.WriteLine($"DesignTimeDbContextFactory: using base path = {path}");
            Console.WriteLine($"DesignTimeDbContextFactory: using connection string = {connectionString}");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException($"Could not find connection string named {nameof(TranslationContext)}");
            }

            DbContextOptionsBuilder<TranslationContext> dbContextOptionsBuilder =
                new DbContextOptionsBuilder<TranslationContext>();
            dbContextOptionsBuilder.UseSqlServer(connectionString);

            return new TranslationContext(dbContextOptionsBuilder.Options);
        }
    }
}

