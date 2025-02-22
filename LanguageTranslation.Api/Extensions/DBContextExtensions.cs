using LanguageTranslation.Infastructure;
using Microsoft.EntityFrameworkCore;
using LanguageTranslation.Infastructure.Extensions;

namespace LanguageTranslation.Api.Extensions
{
    public static class DBContextExtensions
    {
        public static void ConfigureDb(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<TranslationContext>(options =>
             options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(TranslationContext)), options =>
             {
                 options.MigrationsAssembly("LanguageTranslation.Infastructure");
                 options.EnableRetryOnFailure();
             }));

            using (var scope = builder.Services.BuildServiceProvider().CreateScope())
            {
                var serviceProvide = scope.ServiceProvider;
                var context = serviceProvide.GetService<TranslationContext>();
                context?.SeedData();
            }
        }
    }
}

