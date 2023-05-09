using GildedRose.Repository.Models;
using MediatR;


namespace GildedRose.Repository.Commands.Items
{
    public interface ISeedItemsCommand : ICommand<List<Item>, Unit>
    {
        new Task<Unit> ExecuteAsync(List<Item> itemsToSeed, CancellationToken cancellationToken = default);
    }
}
