using LanguageTranslation.Api.DelegateHandlers;
using LanguageTranslation.Api.Services.Funtransaction;
using LanguageTranslation.Api.Settings;
using Microsoft.Extensions.Options;

namespace LanguageTranslation.Api.Extensions
{
	public static class HttpClientExtensions
	{
		public static void AddHttpClientServices(this IServiceCollection services)
		{
            var sp = services.BuildServiceProvider();
            services.AddScoped<LoggingDelegateHandler>();
            services.AddHttpClient<IFuntranslationService, FuntranslationService>(client =>
            {
                FuntranslationSetting funTranslationSetting = sp.GetRequiredService<IOptions<FuntranslationSetting>>().Value;
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(funTranslationSetting.BaseUrl ?? string.Empty);
             
            }).AddHttpMessageHandler(provider =>
            {
                return provider.GetRequiredService<LoggingDelegateHandler>();
            }).ConfigurePrimaryHttpMessageHandler(_ => new HttpClientHandler
            {

                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            });
        }
	}
}

