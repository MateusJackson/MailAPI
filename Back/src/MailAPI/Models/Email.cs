using System.ComponentModel.DataAnnotations.Schema;

namespace MailAPI.Models
{
    public class Email
    {
        public int Id { get; set; }
        [NotMapped]
        public string[] Emails { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; }     

        public Email()
        {
        }  
    }
}