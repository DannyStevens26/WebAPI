using Microsoft.AspNetCore.Mvc;
using OrdersOrganiser.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace OrdersOrganiser.BusinessLayer.Commands
{
    public class SendEmailCommand : ISendEmailCommand
    {
        private const string apiKey = "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";

        public async Task<IActionResult> Execute(Account account, string subject, string body)
        {
            var client = new SendGridClient(apiKey);

            var from = new EmailAddress("frankman@hotmail.co.uk", "Danny Stevens");
            var to = new EmailAddress(account.Email, $"{account.FirstName} {account.LastName}");

            var msg = MailHelper.CreateSingleEmail(from, to, subject, "", body);
            var response = await client.SendEmailAsync(msg);

            return new ObjectResult("Email attempted") { StatusCode = (int)response.StatusCode };
        }
    }
}
