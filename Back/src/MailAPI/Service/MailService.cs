using System.Net.Mail;
using System.Net;
using MailAPI.Contract;
namespace MailApi.Service
{
    public class MailService : IMailService
    {

        public string emailFromAddress => "testesdotnetsystemmail@gmail.com";
        public string password => "emwukcxtinmmyvfg";

        public int Id { get; set; }
        public void AddEmailsToMailMessage(MailMessage mailMessage, string[] emails)
        {
            foreach (var email in emails)
            {
                mailMessage.To.Add(email);
            }
        }
        public void SendMail(string[] emails, string subject, string body, bool isHtml = true)
        {
            using(MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(emailFromAddress);
                AddEmailsToMailMessage(mailMessage, emails);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = isHtml;
                mailMessage.Priority = MailPriority.Normal;
                using(SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(emailFromAddress, password);
                    smtp.UseDefaultCredentials = false;
                    smtp.EnableSsl = true;
                    smtp.Send(mailMessage);
                }
            }

        }
    }
}