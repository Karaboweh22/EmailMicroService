namespace MyApp.Configuration
{
    /// <summary>
    /// Represents a collection of configurable options for the application.
    /// </summary>
    internal class Options
    {
        /// <summary>
        /// Gets or sets the application name.
        /// </summary>
        public string AppName { get; set; }

        /// <summary>
        /// Gets or sets the application version.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the connection string for the database.
        /// </summary>
        public string DatabaseConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the API key for external services.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets or sets the timeout in seconds for HTTP requests.
        /// </summary>
        public int HttpRequestTimeout { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether detailed logging is enabled.
        /// </summary>
        public bool EnableDetailedLogging { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of retries for failed operations.
        /// </summary>
        public int MaxRetries { get; set; }

        /// <summary>
        /// Gets or sets the interval between retries in milliseconds.
        /// </summary>
        public int RetryInterval { get; set; }

        /// <summary>
        /// Gets or sets the file path for storing logs.
        /// </summary>
        public string LogFilePath { get; set; }

        /// <summary>
        /// Gets or sets the email settings for notifications.
        /// </summary>
        public EmailSettings EmailSettings { get; set; }

        // Additional settings can be added here as needed
    }

    /// <summary>
    /// Represents the email settings configuration.
    /// </summary>
    internal class EmailSettings
    {
        /// <summary>
        /// Gets or sets the SMTP server address.
        /// </summary>
        public string SmtpServer { get; set; }

        /// <summary>
        /// Gets or sets the SMTP server port.
        /// </summary>
        public int SmtpPort { get; set; }

        /// <summary>
        /// Gets or sets the email address used for sending emails.
        /// </summary>
        public string SenderEmail { get; set; }

        /// <summary>
        /// Gets or sets the email password.
        /// </summary>
        public string SenderPassword { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use SSL for the SMTP connection.
        /// </summary>
        public bool UseSsl { get; set; }
    }
}
