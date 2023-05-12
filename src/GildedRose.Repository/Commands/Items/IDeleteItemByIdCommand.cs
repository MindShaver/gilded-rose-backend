using MediatR;

namespace GildedRose.Repository.Commands.Items
{
    public interface IDeleteItemByIdCommand : ICommand<Guid, Unit>
    {
        new Task<Unit> ExecuteAsync(Guid itemToDelete, CancellationToken cancellationToken = default);
    }
}
