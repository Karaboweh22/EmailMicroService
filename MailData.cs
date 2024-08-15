namespace Sendingmail
{
    public class MailData
    {
        /// <summary>
        /// Gets or sets the email address of the recipient.
        /// </summary>
        public string EmailToId { get; set; }

        /// <summary>
        /// Gets or sets the name of the recipient.
        /// </summary>
        public string EmailToName { get; set; }

        /// <summary>
        /// Gets or sets the subject of the email.
        /// </summary>
        public string EmailSubject { get; set; }

        /// <summary>
        /// Gets or sets the body content of the email.
        /// </summary>
        public string EmailBody { get; set; }
    }
}

