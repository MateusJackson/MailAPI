using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MailAPI.Contract
{
    public interface IMailService
    {
        int Id { get; set; }
        void AddEmailsToMailMessage(MailMessage mailMessage, string[] emails)
        {
        }

        void SendMail(string[] emails, string subject, string body, bool isHtml = true)
        {
        }
    }
}