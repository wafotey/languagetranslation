using System;
using LanguageTranslation.Api.Settings;

namespace LanguageTranslation.Api.Extensions
{
	public static class SettingsExtensions
	{
        public static void AddSettings(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<FuntranslationSetting>(builder.Configuration.GetSection(nameof(FuntranslationSetting)));
        }
	}
}

