using System.Collections.Generic;
using System.Linq;
using OrdersOrganiser.BusinessLayer.Commands;
using OrdersOrganiser.Models;

namespace OrdersOrganiser.BusinessLayer.StrategyResolver
{
    public class DeleteResolver : IDeleteResolver
    {
        private readonly IEnumerable<IDeleteCommand> _deleteCommands;

        public DeleteResolver(IEnumerable<IDeleteCommand> deleteCommands)
        {
            _deleteCommands = deleteCommands;
        }

        public IDeleteCommand Resolve(DeleteType deleteType)
        {
            return _deleteCommands.FirstOrDefault(x => x.deleteType == deleteType);
        }
    }
}
