using System.Threading.Tasks;
using OrdersOrganiser.Models;

namespace OrdersOrganiser.BusinessLayer.Commands
{
    public interface IDeleteCommand
    {
        DeleteType deleteType { get; }

        Task Execute(int id);
    }
}
