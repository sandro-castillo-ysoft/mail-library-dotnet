
namespace mail_library.Provider.MicrosoftGraph {
    public sealed class MicrosoftGraphConstants {
        public const string DEFAULT_CACHE_FILENAME = "msal.cache";
        public const string DEFAULT_TENANT = "common";
        public const string DEFAULT_BASE_URL = @"https://graph.microsoft.com/v1.0";
        public const string DEFAULT_AUTHORITY_FORMAT = "https://login.microsoftonline.com/{0}/";
        public static readonly string[] DEFAULT_SCOPES = { "https://graph.microsoft.com/Mail.ReadWrite", "https://graph.microsoft.com/Mail.Send", "https://graph.microsoft.com/User.Read" };

    }
}
