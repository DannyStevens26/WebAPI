namespace OrdersOrganiser.BusinessLayer
{
    public interface IValidatePostcodeCommand
    {
        public bool Execute(string postcode);
    }
}
