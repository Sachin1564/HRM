using EntityLayer.Identity.Entities;
using EntityLayer.Identity.ViewModels;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Helpers.Identity.EmailHelper
{
    public interface IEmailSendMethod
    {
        Task SendResetPasswordLinkWithEmailToken(string resetPasswordLink , string toEmail);
    }
    public class EmailSendMethod : IEmailSendMethod
    {
        private readonly GmailInformationVM _emailInfo;

        public EmailSendMethod(IOptions<GmailInformationVM>emailInfo)
        {
            _emailInfo = emailInfo.Value;
        }

        public async Task SendResetPasswordLinkWithEmailToken(string resetPasswordLink, string toEmail)
        {
            var smtpClient = new SmtpClient();

            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Host = _emailInfo.Host;
            smtpClient.Port = 587;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(_emailInfo.Email, _emailInfo.Password);
            smtpClient.EnableSsl = false;

            var mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_emailInfo.Email);
            mailMessage.To.Add(toEmail);
            mailMessage.Subject = "Password ResetLink | HRM";
            mailMessage.Body = $@"<h1> Reset Password Link</h1>
                                   <h5>Click <a href='{resetPasswordLink}'>to reset your password</a></h5>";
            mailMessage.IsBodyHtml = true;

            await smtpClient.SendMailAsync(mailMessage);
            
        }
       
    }
}
