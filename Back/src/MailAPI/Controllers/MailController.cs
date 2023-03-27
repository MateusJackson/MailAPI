using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailAPI.Contract;
using MailAPI.Data.Context;
using MailAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MailAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class MailController : ControllerBase
    {
        private readonly IMailService _mailService;
        private readonly MailContext _context;

        public MailController(IMailService mailService, MailContext context)
        {
            _mailService = mailService;
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var GetMailById = await _context.Email.FindAsync(id);
            return (GetMailById == null) ? NotFound() : Ok(GetMailById);
        }

        [HttpPost]
        public IActionResult SendMail([FromBody] Email email)
        {
            try
            {
                _mailService.SendMail(email.Emails, email.Subject, email.Body, email.IsHtml);
                return Ok();
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro: " + e.Message);
            }
        }
    }
}
