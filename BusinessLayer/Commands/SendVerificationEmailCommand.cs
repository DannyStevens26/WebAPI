using Microsoft.AspNetCore.Mvc;
using OrdersOrganiser.Models;
using System.Threading.Tasks;
using System;

namespace OrdersOrganiser.BusinessLayer.Commands
{
    public class SendVerificationEmailCommand : ISendVerificationEmailCommand
    {
        private readonly OrderContext _context;
        private readonly ISendEmailCommand _sendEmail;
        public SendVerificationEmailCommand(OrderContext context, ISendEmailCommand sendEmail)
        {
            _context = context;
            _sendEmail = sendEmail;
        }
        public async Task<IActionResult> Execute(int id)
        {
            var user = await _context.Accounts.FindAsync(id);

            if (user == null)
            {
                return new ObjectResult("User not found") { StatusCode = 404 };
            }
            
            if (user.IsVerified == true)
            {
                return new OkObjectResult("Email already verified");
            }

            var rand = new Random();

            var verifyCode = rand.Next(100000, 999999);

            user.VerifyCode = verifyCode;

            _context.SaveChanges();

            string subject = "Email verification";
            string body = $"<strong>Use this code to verify your account: {verifyCode} </strong>";

            return await _sendEmail.Execute(user, subject, body);
        }
    }
}
