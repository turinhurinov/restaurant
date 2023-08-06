using Restaurant.Business.Services.Abstract;
using Restaurant.Framework;
using Restaurant.Model;

namespace Restaurant.Business.Services
{
    public class EmailService : IEmailService
    {
        #region ctor

        readonly ISmtpService smtpService;

        public EmailService(ISmtpService smtpService)
        {
            this.smtpService = smtpService;
        }

        #endregion

        public void SendReservationApprovalEmail(string customerEmailAddress, Reservation reservation)
        {
            var subject = "Rezervasyon Onayı";
            var message = $"Sayın {reservation.CustomerName}, rezervasyonunuz başarıyla alındı. Masa No: {reservation.TableNumber}, Tarih: {reservation.ReservationDate}, Kişi Sayısı: {reservation.NumberOfGuests}";
            smtpService.SendEmail(customerEmailAddress, subject, message);
        }
    }
}