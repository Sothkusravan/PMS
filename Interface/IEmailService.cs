using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pharma.Interface
{
    public interface IEmailService
    {
        Task SendApprovalByEmail(string name, string recipientEmail, string password);
        Task DoctorByEmail(string name, string recipientEmail, string password);
        Task PharmacistByEmail(string name, string recipientEmail);
        Task SalesManByEmail(string name, string recipientEmail);

    }
}