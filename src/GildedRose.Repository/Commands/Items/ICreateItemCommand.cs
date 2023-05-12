using GildedRose.Repository.Models;
using MediatR;

namespace GildedRose.Repository.Commands.Items
{
    public interface ICreateItemCommand : ICommand<Item, Unit>
    {
        new Task<Unit> ExecuteAsync(Item itemToCreate, CancellationToken cancellationToken = default);
    }
}
