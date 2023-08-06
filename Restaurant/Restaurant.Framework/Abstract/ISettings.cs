using System;

namespace Restaurant.Framework.Abtract
{
    public interface ISettings
    {
        string SmtpAddress { get; }
		string SmtpUsername { get; }
		string SmtpPassword { get; }
		int SmtpPortNumber { get; }
		bool SmtpEnableSSL { get; }
		string SupportEmailAddress { get; }
		string DefaultMailSenderName { get; }
    }
}