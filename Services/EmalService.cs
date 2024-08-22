using System;
using System.Threading.Tasks;
using pharma.Interface;

namespace pharma.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailService _emailRepository;

        public EmailService(IEmailService emailRepository)
        {
            _emailRepository = emailRepository ?? throw new ArgumentNullException(nameof(emailRepository));
        }

        public async Task SendApprovalByEmail(string name, string recipientEmail, string password)
        {
            try
            {
                await _emailRepository.SendApprovalByEmail(name, recipientEmail, password);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in EmailService: {ex.Message}");
                throw;
            }
        }

        public async Task DoctorByEmail(string name, string recipientEmail, string password)
        {
            try
            {
                await _emailRepository.DoctorByEmail(name, recipientEmail, password);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in EmailService: {ex.Message}");
                throw;
            }
        }
        public async Task PharmacistByEmail(string name, string recipientEmail)
        {
            try
            {
                await _emailRepository.PharmacistByEmail(name, recipientEmail);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in EmailService: {ex.Message}");
                throw;
            }
        }

         public async Task SalesManByEmail(string name, string recipientEmail)
        {
            try
            {
                await _emailRepository.SalesManByEmail(name, recipientEmail);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in EmailService: {ex.Message}");
                throw;
            }
        }
    }
}
