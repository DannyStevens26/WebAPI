using System;
using System.ComponentModel.DataAnnotations;

namespace OrdersOrganiser.Models
{
    public class Account
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Guid AddressReference { get; set; }
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public int VerifyCode { get; set; }
        public bool IsVerified { get; set; }
    }
}
