using GildedRose.Repository.Models;
using MediatR;

namespace GildedRose.Repository.Commands.Items
{
    public interface IUpdateProcessedItemsCommand : ICommand<IList<Item>, Unit>
    {
        new Task<Unit> ExecuteAsync(IList<Item> itemsToUpdate, CancellationToken cancellationToken = default);
    }
}
