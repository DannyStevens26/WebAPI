using Microsoft.AspNetCore.Mvc;
using OrdersOrganiser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersOrganiser.BusinessLayer.Commands
{
    public interface ISendEmailCommand
    {
        public Task<IActionResult> Execute(Account account, string subject, string body);
    }
}
