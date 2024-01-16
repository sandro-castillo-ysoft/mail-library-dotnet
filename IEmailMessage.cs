using System.Net.Mail;

namespace mail_library {
    public interface IEmailMessage {
        IEmailMessage AddSubject(string subject);
        IEmailMessage AddHtmlBody(string htmlBody);
        IEmailMessage AddAttachment(string name, string filePath);

        IEmailMessage AddRecipientTo(string recipient);
        IEmailMessage AddRecipientsTo(string[] recipients);
        IEmailMessage AddRecipientTo(MailAddress recipient);
        IEmailMessage AddRecipientsTo(IEnumerable<MailAddress> recipients);

        IEmailMessage AddRecipientCc(string recipient);
        IEmailMessage AddRecipientsCc(string[] recipients);
        IEmailMessage AddRecipientCc(MailAddress recipient);
        IEmailMessage AddRecipientsCc(IEnumerable<MailAddress> recipients);

        IEmailMessage AddRecipientBcc(string recipient);
        IEmailMessage AddRecipientsBcc(string[] recipients);
        IEmailMessage AddRecipientBcc(MailAddress recipient);
        IEmailMessage AddRecipientsBcc(IEnumerable<MailAddress> recipients);

        T SealMessage<T>() where T : IEmailMessage {
            return (T)this;
        }
    }
}
