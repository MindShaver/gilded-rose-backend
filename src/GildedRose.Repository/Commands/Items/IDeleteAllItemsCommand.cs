using GildedRose.Repository.Models;
using MediatR;

namespace GildedRose.Repository.Commands.Items
{
    public interface IDeleteAllItemsCommand : ICommand<IEnumerable<Item>, Unit>
    {
        new Task<Unit> ExecuteAsync(IEnumerable<Item> itemsToDelete, CancellationToken cancellationToken = default);
    }
}
