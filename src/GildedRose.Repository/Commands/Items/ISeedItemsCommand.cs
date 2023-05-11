using GildedRose.Repository.Models;
using MediatR;


namespace GildedRose.Repository.Commands.Items
{
    public interface ISeedItemsCommand : ICommand<IList<Item>, Unit>
    {
        new Task<Unit> ExecuteAsync(IList<Item> itemsToSeed, CancellationToken cancellationToken = default);
    }
}
