using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mail_library.Provider {
    public partial class MailBuilderOptions {
        // Common settings
        public ProviderType Type { get; set; } = ProviderType.SMTP;

        public string? ServiceAccount { get; set; }
        public string? SendAs { get; set; }
        public string? SendAsDisplayName {  get; set; }
        public bool? SaveSentItems { get; set; }

        //OAuth
        // Move things here as necessary
    }

    partial class MailBuilderOptions {
        // Microsoft Graph settings
        public string? ClientId { get; set; }
        public string? TenantId { get; set; }
        public string? Authority { get; set; }
        public string[]? Scopes { get; set; }
        public string? RedirectUri { get; set; }
        public string? CacheFolder { get; set; }
        public string? CacheFileName {  get; set; }
        public string? BaseUrl { get; set; }
    }

    public partial class MailBuilderOptions {
        // Google Apis settings
    }

    public partial class MailBuilderOptions {
        // SMTP Settings
    }

    public enum ProviderType {
        Other,
        SMTP,
        Microsoft,
        MicrosoftGraph,
        Office365,
        Google,
        GoogleApis
    }
}
