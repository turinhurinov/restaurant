using System;
using System.Diagnostics.CodeAnalysis;

namespace Restaurant.Framework
{
    [ExcludeFromCodeCoverage]
    public class SmtpService : ISmtpService
    {
        public void SendEmail(string recipient, string subject, string message)
        {
            //TODO: implement
            throw new NotImplementedException();
        }
    }
}
