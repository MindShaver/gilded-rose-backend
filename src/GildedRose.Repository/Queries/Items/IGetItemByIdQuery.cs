using GildedRose.Repository.Models;

namespace GildedRose.Repository.Queries.Items
{
    public interface IGetItemByIdQuery : ISingleQuery
    {
        new Task<Item> ExecuteAsync(Guid itemId, CancellationToken cancellationToken = default);
    }
}
