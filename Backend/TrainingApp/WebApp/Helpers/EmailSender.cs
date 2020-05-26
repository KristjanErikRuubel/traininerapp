using System;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace WebApp.Helpers
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("jalgpallitreeninguapp@gmail.com");
                mail.To.Add("kristjan-e@hotmail.com");
                mail.Subject = "Test Mail";
                mail.Body = "This is for testing SMTP mail from GMAIL";
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("jalgpallitreeninguapp@gmail.com", "Tuubik1234");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Task.CompletedTask;
        }

        public void testEmail()
        {
           
        }
        
    }
}