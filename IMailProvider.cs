
namespace mail_library {
    public interface IMailProvider {
        public abstract Task<bool> SendMailAsync(EmailMessage message, CancellationToken? cancellationToken = null);

        public abstract Task<List<EmailMessage>> ReadMailboxAsync(CancellationToken? cancellationToken = null);

        // Maybe?
        // public abstract Task<List<EmailMessage>> ReadMailboxAsync(Func<EmailMessage, bool> predicate, CancellationToken? cancellationToken = null);

    }
}
