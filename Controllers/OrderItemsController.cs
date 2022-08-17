using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrdersOrganiser.BusinessLayer;
using OrdersOrganiser.BusinessLayer.Commands;
using OrdersOrganiser.BusinessLayer.StrategyResolver;
using OrdersOrganiser.Models;
using OrdersOrganiser.BusinessLayer.Exceptions;
using Microsoft.AspNetCore.Cors;

namespace OrdersOrganiser.Controllers
{
    [Route("api/OrderItems")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly OrderContext _context;
        private readonly ICreateOrderCommand _createOrderCommand;
        private readonly ICheckOrderItem _checkOrderItem;
        private readonly ICreateAccountCommand _createAccountCommand;
        private readonly IDeleteResolver _deleteResolver;
        private readonly ISendVerificationEmailCommand _sendVerificationEmailCommand;

        public OrderItemsController(
            OrderContext context, 
            ICreateOrderCommand createOrderCommand, 
            ICheckOrderItem checkOrderItem, 
            ICreateAccountCommand createAccountCommand, 
            IDeleteResolver deleteResolver,
            ISendVerificationEmailCommand sendVerificationEmailCommand)
        {
            _context = context;
            _createOrderCommand = createOrderCommand;
            _checkOrderItem = checkOrderItem;
            _createAccountCommand = createAccountCommand;
            _deleteResolver = deleteResolver;
            _sendVerificationEmailCommand = sendVerificationEmailCommand;
        }

        // GET: api/OrderItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompositeProfile>>> GetOrderItems()
        {
            var addresses = await _context.Addresses.ToListAsync();

            List<CompositeProfile> compositeOrders = new List<CompositeProfile>();

            foreach (var address in addresses)
            {
                var order = await _context.OrderItems
                    .Where(o => o.AddressReference == address.AddressReference)
                    .ToListAsync();

                var account = _context.Accounts
                    .FirstOrDefault(acc => acc.AddressReference == address.AddressReference);

                compositeOrders.Add(new CompositeProfile()
                    {
                        OrderItem = order, 
                        Address = address, 
                        Account = account
                    });
            }

            return compositeOrders;
        }

        // GET: api/OrderItems/5
        [HttpGet("find/{id}")]
        public ActionResult<OrderItem> FindItem(int id)
        {
            var orderItem = _context.OrderItems.Find(id);

            if (orderItem == null)
            {
                return NotFound();
            }

            return orderItem;
        }

        [HttpGet("check/{id}")]
        public IActionResult Check(int id)
        {
            return _checkOrderItem.Check(id);
        }

        // PUT: api/orderitems/create/order
        [HttpPost("create/order")]
        public IActionResult CreateOrderItem([FromBody] CompositeOrderItem compositeOrderItem)
        {
            var address = compositeOrderItem.Address;

            var orderItem = compositeOrderItem.OrderItem;

            try
            {
                return _createOrderCommand.Create(orderItem, address);
            }
            catch (PostcodeNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (PostcodeApiServiceException e)
            {
                return new ObjectResult(e) { StatusCode = 502 };
            }
        }

        [HttpPost("create/account")]
        public IActionResult CreateAccount([FromBody] CompositeAccount compositeAccount)
        {
            var address = compositeAccount.Address;

            var account = compositeAccount.Account;
            try
            {
                return _createAccountCommand.Create(account, address);
            }
            catch(PostcodeNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch(PostcodeApiServiceException e)
            {
                return new ObjectResult(e) { StatusCode = 502 };
            }
        }

        // DELETE: api/OrderItems/order/5
        [HttpDelete("delete/{deleteType}/{id}")]
        public async Task<IActionResult> DeleteOrderItem(
            [FromRoute] DeleteType deleteType, 
            [FromRoute] int id)
        {
            var deleteCommand = _deleteResolver.Resolve(deleteType);

            try
            {
                await deleteCommand.Execute(id);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpGet("verify/email/{id}")]
        public async Task<IActionResult> SendVerificationEmail(int id)
        {
            return await _sendVerificationEmailCommand.Execute(id);
        }

        [HttpPost("verify/code/{id}")]
        public async Task<IActionResult> EnterVerificationCode(int id, [FromHeader] int verificationCode)
        {
            var account = await _context.Accounts.FindAsync(id);

            if(account == null)
            {
                return NotFound();
            }

            if(verificationCode == account.VerifyCode)
            {
                account.IsVerified = true;

                await _context.SaveChangesAsync();

                return new OkObjectResult("Your email has been verified.");
            }
            else
            {
                return new OkObjectResult("The code you have entered is incorrect.");
            }
        }
    }
}
