using System;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Smtp;
using pharma.Interface; 

namespace pharma.Repository
{
    public class EmailRepository : IEmailService
    {
        public async Task SendApprovalByEmail(string name, string recipientEmail, string password)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("PMS", "sothkusravan9@gmail.com"));
                message.To.Add(new MailboxAddress("", recipientEmail));
                message.Subject = "Your PMS Credentials";
                message.Body = new TextPart("plain")
                {
                    Text = $" Your account has been Approved. 🎉 \nHere are your credentials for PMS application:\n\nUsername: {name}\nPassword: {password}\n\n! Now you have an access to all drugs and you can request drugs that Oraganization want"
                };

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("smtp.gmail.com", 587, false);
                    await client.AuthenticateAsync("sothkusravan9@gmail.com", "zssy cwqv goen apth");
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
                throw;
            }
        }

        public async Task DoctorByEmail(string name, string recipientEmail, string password)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("PMS", "sothkusravan9@gmail.com"));
                message.To.Add(new MailboxAddress("", recipientEmail));
                message.Subject = "Your Approval";
                message.Body = new TextPart("plain")
                {
                    Text = $" Hey mr {name}\n\n\nYour account has been Approved. 🎉 \n\n Now you have an access to all drugs and you can request drugs that Oraganization want"
                };

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("smtp.gmail.com", 587, false);
                    await client.AuthenticateAsync("sothkusravan9@gmail.com", "zssy cwqv goen apth");
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
                throw;
            }
        }
        public async Task PharmacistByEmail(string name, string recipientEmail)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("PMS", "sothkusravan9@gmail.com"));
                message.To.Add(new MailboxAddress("", recipientEmail));
                message.Subject = "Your Approval";
                message.Body = new TextPart("plain")
                {
                    Text = $" Hey mr {name}\n\n\nYour account has been Approved. 🎉 \n\n Now you can SignIn to PMS application.\n\n Now you can give drugs to customers by using your credentials"
                };

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("smtp.gmail.com", 587, false);
                    await client.AuthenticateAsync("sothkusravan9@gmail.com", "zssy cwqv goen apth");
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
                throw;
            }
        }
        public async Task SalesManByEmail(string name, string recipientEmail)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("PMS", "sothkusravan9@gmail.com"));
                message.To.Add(new MailboxAddress("", recipientEmail));
                message.Subject = "Your Approval";
                message.Body = new TextPart("plain")
                {
                    Text = $" Hey mr {name}\n\n\nYour account has been Approved. 🎉 \n\n Now you can SignIn to PMS application.\n\n You can upload your drugs details and you can observe order placed by PMS organisation."
                };

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("smtp.gmail.com", 587, false);
                    await client.AuthenticateAsync("sothkusravan9@gmail.com", "zssy cwqv goen apth");
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
                throw;
            }
        }
    }
}
