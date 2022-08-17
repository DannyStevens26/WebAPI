using OrdersOrganiser.BusinessLayer.Commands;
using OrdersOrganiser.Models;

namespace OrdersOrganiser.BusinessLayer.StrategyResolver
{
    public interface IDeleteResolver
    {
        IDeleteCommand Resolve(DeleteType deleteType);
    }
}
