namespace Sendingmail
{
    public class MailSettings
    {
        /// <summary>
        /// Gets or sets the email address used for sending emails.
        /// </summary>
        public string EmailId { get; set; }

        /// <summary>
        /// Gets or sets the name of the sender.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the username for the email account.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password for the email account.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the SMTP server host name or IP address.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Gets or sets the port number used by the SMTP server.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use SSL for the SMTP connection.
        /// </summary>
        public bool UseSSL { get; set; }
    }
}
