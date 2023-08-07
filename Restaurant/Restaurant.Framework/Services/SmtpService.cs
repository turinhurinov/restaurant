using Restaurant.Framework.Abtract;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Mail;

namespace Restaurant.Framework.Services
{
    [ExcludeFromCodeCoverage]
    public class SmtpService : ISmtpService
    {

        #region ctor
        
        readonly ISettings settings;

        public SmtpService(ISettings settings)
        {
            this.settings = settings;
        }

        #endregion

        public bool SendMail(MailMessage mail)
        {
            //SMTP ayarları tanımlandığında bir sonraki satır kaldırılır. Şimdilik başarılı gönderim olduğu varsayılıyor.
            return true;

            var smtpClient = CreateSmtpClient();
            bool mailSent = false;

            try
            {
                smtpClient.Send(mail);
                mailSent = true;
            }
            catch (Exception ex)
            {
                mailSent = false;
                //Log error
            }
            finally
            {
                mail.Dispose();
                smtpClient = null!;
            }

            return mailSent;
        }

        SmtpClient CreateSmtpClient()
        {
            string smtpAddress = settings.SmtpAddress;
            string smtpUserName = settings.SmtpUsername;
            string smtpPassword = settings.SmtpPassword;
            int portNumber = settings.SmtpPortNumber;

            var smtpClient = new SmtpClient(smtpAddress, portNumber);
            smtpClient.EnableSsl = settings.SmtpEnableSSL;
            smtpClient.Credentials = new System.Net.NetworkCredential(smtpUserName, smtpPassword);
            return smtpClient;
        }
    }
}
