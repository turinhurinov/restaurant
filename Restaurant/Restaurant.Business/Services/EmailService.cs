using Restaurant.Business.Abstract;
using Restaurant.Framework.Abtract;
using Restaurant.Model;

namespace Restaurant.Business.Services
{
    public class EmailService : IEmailService
    {
        #region ctor

        readonly ISmtpService smtpService;
        readonly IMailMessageFactory mailMessageFactory;
        readonly ISettings settings;

        public EmailService(
            ISmtpService smtpService, 
            IMailMessageFactory mailMessageFactory,
            ISettings settings)
        {
            this.smtpService = smtpService;
            this.mailMessageFactory = mailMessageFactory;
            this.settings = settings;
        }

        #endregion

        public void SendReservationApprovalEmail(string customerEmailAddress, Reservation reservation)
        {
            var subject = "Rezervasyon Onayı";
            var message = $"Sayın {reservation.CustomerName}, rezervasyonunuz başarıyla alındı. Masa No: {reservation.TableNumber}, Tarih: {reservation.ReservationDate}, Kişi Sayısı: {reservation.NumberOfGuests}";
            string senderEmailAddress = settings.SupportEmailAddress;
            string senderName = settings.DefaultMailSenderName;

            var mail = mailMessageFactory.CreateMailMessage(
                senderEmailAddress,
                senderName,
                subject,
                customerEmailAddress,
                false,
                message);

            smtpService.SendMail(mail);
        }
    }
}