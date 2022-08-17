using System;

namespace OrdersOrganiser.BusinessLayer.Exceptions
{
    public class PostcodeApiServiceException : Exception
    {
        public PostcodeApiServiceException(string message) : base(message)
        {
        }
    }
}
