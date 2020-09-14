using System.Reflection;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Json;
using Abp.Reflection.Extensions;

namespace ClinicManager.Localization
{
    public static class ClinicManagerLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Languages.Add(new LanguageInfo("en", "English", "famfamfam-flags england", isDefault: true));
            localizationConfiguration.Languages.Add(new LanguageInfo("tr", "Türkçe", "famfamfam-flags tr"));

            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(ClinicManagerConsts.LocalizationSourceName,
                    new JsonEmbeddedFileLocalizationDictionaryProvider(
                        typeof(ClinicManagerLocalizationConfigurer).GetAssembly(),
                        "ClinicManager.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}