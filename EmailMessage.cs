using System.Net.Mail;


namespace mail_library {
    public partial class EmailMessage : IEmailMessage {
        internal string HtmlBody { get; set; }
        internal string Subject { get; set; }
        internal MailAddressCollection MailTo { get; set; }
        internal MailAddressCollection MailCc { get; set; }
        internal MailAddressCollection MailBcc { get; set; }
        internal Dictionary<string, string> Attachments { get; set; }

        private EmailMessage() {
            HtmlBody = string.Empty;
            Subject = string.Empty;
            MailTo = new MailAddressCollection();
            MailCc = new MailAddressCollection();
            MailBcc = new MailAddressCollection();
            Attachments = new();
        }
    }

    // Interface implementation
    partial class EmailMessage {
        public static IEmailMessage BeginComposing() {
            return new EmailMessage();
        }

        private IEmailMessage PopulateText(string source, IDictionary<string, object> variables) {
            string output = source;

            foreach (var valuePair in variables)
                output = output.Replace(valuePair.Key, valuePair.Value.ToString());

            HtmlBody = output;

            return this;
        }
        private IEmailMessage AddRecipient(MailAddressCollection collection, string recipient) {
            if (!collection.Any(c => c.Address == recipient))
                collection.Add(recipient);

            return this;
        }
        private IEmailMessage AddRecipient(MailAddressCollection collection, MailAddress recipient) {
            if (!collection.Any(c => c.Address == recipient.Address))
                collection.Add(recipient);

            return this;
        }
        private IEmailMessage AddRecipients(MailAddressCollection collection, string[] recipients) {
            foreach (var recipient in recipients)
                AddRecipient(collection, recipient);

            return this;
        }
        private IEmailMessage AddRecipients(MailAddressCollection collection, IEnumerable<MailAddress> recipients) {
            foreach (var recipient in recipients)
                AddRecipient(collection, recipient);

            return this;
        }

        public IEmailMessage AddSubject(string subject) {
            Subject = subject;

            return this;
        }
        public IEmailMessage PopulateBody(IDictionary<string, object> variables) => PopulateText(HtmlBody, variables);
        public IEmailMessage AddHtmlBody(string htmlBody) {
            HtmlBody = htmlBody;

            return this;
        }
        public IEmailMessage PopulateSubject(IDictionary<string, object> variables) => PopulateText(Subject, variables);

        public IEmailMessage AddAttachment(string name, string filePath) {
            Attachments[name] = filePath;

            return this;
        }

        public IEmailMessage AddRecipientTo(string recipient) => AddRecipient(MailTo, recipient);
        public IEmailMessage AddRecipientsTo(string[] recipients) => AddRecipients(MailTo, recipients);
        public IEmailMessage AddRecipientTo(MailAddress recipient) => AddRecipient(MailTo, recipient);
        public IEmailMessage AddRecipientsTo(IEnumerable<MailAddress> recipients) => AddRecipients(MailTo, recipients);

        public IEmailMessage AddRecipientCc(string recipient) => AddRecipient(MailCc, recipient);
        public IEmailMessage AddRecipientsCc(string[] recipients) => AddRecipients(MailCc, recipients);
        public IEmailMessage AddRecipientCc(MailAddress recipient) => AddRecipient(MailCc, recipient);
        public IEmailMessage AddRecipientsCc(IEnumerable<MailAddress> recipients) => AddRecipients(MailCc, recipients);

        public IEmailMessage AddRecipientBcc(string recipient) => AddRecipient(MailBcc, recipient);
        public IEmailMessage AddRecipientsBcc(string[] recipients) => AddRecipients(MailBcc, recipients);
        public IEmailMessage AddRecipientBcc(MailAddress recipient) => AddRecipient(MailBcc, recipient);
        public IEmailMessage AddRecipientsBcc(IEnumerable<MailAddress> recipients) => AddRecipients(MailBcc, recipients);
    }

}
