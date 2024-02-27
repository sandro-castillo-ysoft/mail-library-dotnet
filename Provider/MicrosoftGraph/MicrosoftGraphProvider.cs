using Microsoft.Extensions.Logging;
using static mail_library.Provider.MicrosoftGraph.MicrosoftGraphConstants;

namespace mail_library.Provider.MicrosoftGraph {
    public class MicrosoftGraphProvider : MailProvider {
        public string BaseUrl { get; set; } = DEFAULT_BASE_URL;
        public string ClientId { get; set; }
        public string TenantId { get; set; } = DEFAULT_TENANT;
        public string? RedirectUri { get; set; }
        public string? ServiceAccount { get; set; }
        public string SendAs { get; set; }
        public string? SendAsDisplayName { get; set; }
        public string CacheFolder { get; set; }
        public string CacheFileName { get; set; } = DEFAULT_CACHE_FILENAME;
        public string[] Scopes { get; set; } = DEFAULT_SCOPES;
        public string Authority { get; set; } = string.Format(DEFAULT_AUTHORITY_FORMAT, DEFAULT_TENANT);

        /// <summary>
        /// Connects to Microsoft Graph Mail endpoint on behalf of a User
        /// </summary>
        /// <param name="options">Configuration values passed by appsettings.json</param>
        public MicrosoftGraphProvider(MailBuilderOptions options, ILogger logger) : base(logger) {

            if (!string.IsNullOrWhiteSpace(options.BaseUrl)) BaseUrl = options.BaseUrl;
            if (!string.IsNullOrWhiteSpace(options.TenantId)) TenantId = options.TenantId;
            if (options.Scopes is not null && options.Scopes.Any()) Scopes = options.Scopes;
            if (!string.IsNullOrWhiteSpace(options.CacheFolder)) CacheFolder = options.CacheFolder;
            if (!string.IsNullOrEmpty(options.CacheFileName)) CacheFileName = options.CacheFileName;

            if (options.ClientId is null) throw new ArgumentNullException(nameof(ClientId));
            ClientId = options.ClientId;

            if (options.RedirectUri is null) throw new ArgumentNullException(RedirectUri);
            RedirectUri = options.RedirectUri;

            if (options.ServiceAccount is null) throw new ArgumentNullException(ServiceAccount);
            ServiceAccount = options.ServiceAccount;

            if (options.SendAs is null) SendAs = ServiceAccount;
            else SendAs = options.SendAs;

            SendAsDisplayName = options.SendAsDisplayName;

            if (!string.IsNullOrWhiteSpace(options.Authority)) Authority = options.Authority;
            else Authority = string.Format(DEFAULT_AUTHORITY_FORMAT, TenantId);

            if (CacheFolder is null) throw new ArgumentNullException(CacheFolder);
            Directory.CreateDirectory(CacheFolder);
        }

        public override Task<bool> SendMailAsync(EmailMessage message, CancellationToken? cancellationToken = null) {
            cancellationToken ??= CancellationToken.None;

            throw new NotImplementedException();
        }

        public override Task<List<EmailMessage>> ReadMailboxAsync(CancellationToken? cancellationToken = null) {
            cancellationToken ??= CancellationToken.None;

            throw new NotImplementedException();
        }

        public async Task<Microsoft.Graph.GraphServiceClient> CreateGraphClientAsync(bool interactive, CancellationToken cancellationToken) {
            throw new NotImplementedException();
        }
    }
}
