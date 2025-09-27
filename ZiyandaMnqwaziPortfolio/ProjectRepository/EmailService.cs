using System.Net;
using System.Net.Mail;

namespace ZiyandaMnqwaziPortfolio.ProjectRepository
{
    public class EmailService:IEmailService
    {
        private readonly IConfiguration _config;
        public EmailService(IConfiguration config)
        {
            _config = config;
        }
 

            public async Task sendEmailAsync(string to, string subject, string body)
            {
                var fromEmail = _config["EmailSettings:FromEmail"];
                var smtpHost = _config["EmailSettings:SmtpServer"];
                var smtpPort = int.Parse(_config["EmailSettings:SmtpPort"]);
                var smtpUser = _config["EmailSettings:SmtpUsername"];
                var smtpPass = _config["EmailSettings:SmtpPassword"];

                var mail = new MailMessage(fromEmail, to, subject, body)
                {
                    IsBodyHtml = true
                };

                using var smtp = new SmtpClient(smtpHost, smtpPort)
                {
                    Credentials = new NetworkCredential(smtpUser, smtpPass),
                    EnableSsl = true
                };

            try
            {
                await smtp.SendMailAsync(mail);
            }
            catch (Exception ex)
            {
                // Log the error or handle it gracefully
                throw new InvalidOperationException("Failed to send email.", ex);
            }
        }
        }
    }

