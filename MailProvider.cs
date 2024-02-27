using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace mail_library {
    public abstract class MailProvider : IMailProvider {
        protected readonly ILogger _logger;

        public MailProvider(ILogger logger) {
            _logger = logger;
        }

        public abstract Task<bool> SendMailAsync(EmailMessage message, CancellationToken? cancellationToken = null);
        public abstract Task<List<EmailMessage>> ReadMailboxAsync(CancellationToken? cancellationToken = null);
    }
}
