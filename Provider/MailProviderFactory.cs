using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace mail_library.Provider {
    public sealed class MailProviderFactory {
        public static MailProvider BuildProvider(MailBuilderOptions options, ILogger logger) {

            MailProvider provider = options.Type switch {
                ProviderType.SMTP => throw new NotImplementedException(),
                ProviderType.Microsoft or ProviderType.MicrosoftGraph or ProviderType.Office365 => new MicrosoftGraph.MicrosoftGraphProvider(options, logger),
                ProviderType.Google or ProviderType.GoogleApis => throw new NotImplementedException(),
                _ => throw new IndexOutOfRangeException("Mail provider could not be parsed from configuration file."),
            };

            return provider;
        }

        public static MailProvider BuildProvider(string configurationSection = "MailService", string configurationJsonFile = "appsettings.json", ILogger? logger = null) {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile(configurationJsonFile)
                .Build();

            MailBuilderOptions options = new MailBuilderOptions();
            configuration.Bind(configurationSection, options);

            logger ??= NullLogger<MailProvider>.Instance;

            return BuildProvider(options, logger);
        }
    }
}
